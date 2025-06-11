using Humanizer;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace CODENINJAS.TocaAqui.API.Shared.Interfaces.ASP.Configuration;

/// <summary>
///     Route naming convention to convert controller and action names to kebab-case
/// </summary>
public class KebabCaseRouteNamingConvention : IControllerModelConvention
{
    public void Apply(ControllerModel controller)
    {
        foreach (var selector in controller.Selectors)
        {
            selector.AttributeRouteModel = ReplaceControllerTemplate(selector, controller.ControllerName);
        }

        foreach (var action in controller.Actions)
        {
            foreach (var selector in action.Selectors)
            {
                selector.AttributeRouteModel = ReplaceActionTemplate(selector, action.ActionName);
            }
        }
    }

    private static AttributeRouteModel? ReplaceControllerTemplate(SelectorModel selector, string controllerName)
    {
        return selector.AttributeRouteModel != null 
            ? new AttributeRouteModel
            {
                Template = selector.AttributeRouteModel.Template?.Replace("[controller]", controllerName.Kebaberize())
            } 
            : null;
    }

    private static AttributeRouteModel? ReplaceActionTemplate(SelectorModel selector, string actionName)
    {
        return selector.AttributeRouteModel != null 
            ? new AttributeRouteModel
            {
                Template = selector.AttributeRouteModel.Template?.Replace("[action]", actionName.Kebaberize())
            } 
            : null;
    }
} 
