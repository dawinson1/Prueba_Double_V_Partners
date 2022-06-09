using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace API_DB_Double_V_Partners.Utilidades
{
    public class SwaggerPorVersion : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            var namepaceController = controller.ControllerType.Namespace;
            var versionApi = namepaceController.Split('.').Last().ToLower();
            controller.ApiExplorer.GroupName = versionApi;
        }
    }
}
