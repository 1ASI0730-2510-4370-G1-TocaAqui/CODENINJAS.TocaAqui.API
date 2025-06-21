using CODENINJAS.TocaAqui.API.Payments.Domain.Model.Aggregates;
using CODENINJAS.TocaAqui.API.Payments.Domain.Model.Commands;
using CODENINJAS.TocaAqui.API.Payments.Domain.Model.ValueObjects;
using CODENINJAS.TocaAqui.API.Payments.Domain.Repositories;
using CODENINJAS.TocaAqui.API.Payments.Domain.Services;
using CODENINJAS.TocaAqui.API.Shared.Domain.Repositories;

namespace CODENINJAS.TocaAqui.API.Payments.Application.Internal.CommandServices;

/// <summary>
///     Payment command service implementation
/// </summary>
public class PaymentCommandService : IPaymentCommandService
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PaymentCommandService(IPaymentRepository paymentRepository, IUnitOfWork unitOfWork)
    {
        _paymentRepository = paymentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Payment?> Handle(CreatePaymentCommand command)
    {
        try
        {
            var paymentAmount = new PaymentAmount(command.Amount);
            
            var paymentMethod = command.PaymentMethod.ToLower() switch
            {
                "bank_transfer" => PaymentMethod.BankTransfer(
                    new BankInfo(
                        command.BankAccountNumber ?? "****0000",
                        command.BankName ?? "Banco de Crédito",
                        command.AccountType ?? "savings"
                    )),
                "credit_card" => PaymentMethod.CreditCard(),
                "debit_card" => PaymentMethod.DebitCard(),
                "cash" => PaymentMethod.Cash(),
                _ => PaymentMethod.BankTransfer(new BankInfo("****0000", "Banco de Crédito", "savings"))
            };

            var payment = new Payment(
                command.EventId,
                command.MusicianId,
                command.PromoterId,
                paymentAmount,
                paymentMethod,
                command.Description ?? ""
            );

            await _paymentRepository.AddAsync(payment);
            await _unitOfWork.CompleteAsync();
            
            return payment;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating payment: {ex.Message}");
            return null;
        }
    }

    public async Task<Payment?> Handle(UpdatePaymentStatusCommand command)
    {
        try
        {
            var payment = await _paymentRepository.FindByIdAsync(command.PaymentId);
            if (payment == null) return null;

            payment.UpdateStatus(command.Status, command.Comment ?? "");
            
            _paymentRepository.Update(payment);
            await _unitOfWork.CompleteAsync();
            
            return payment;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating payment status: {ex.Message}");
            return null;
        }
    }
} 