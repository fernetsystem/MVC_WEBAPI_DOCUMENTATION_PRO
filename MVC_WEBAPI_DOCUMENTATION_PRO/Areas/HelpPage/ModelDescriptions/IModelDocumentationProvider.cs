using System;
using System.Reflection;

namespace MVC_WEBAPI_DOCUMENTATION_PRO.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}