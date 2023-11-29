namespace DemyAI {
    public partial class AppShell : Shell {
        public AppShell(AppShellViewModel appShellViewModel) {
            InitializeComponent();

            BindingContext = appShellViewModel;

            // Get the assembly where this code is executing
            var assembly = GetType().Assembly;

            // Define the namespace where the views are located using a constant or variable
            var viewNamespace = $"{assembly.GetName()}.{Constants.VIEWS}";

            // Dictionary to hold discovered routes, mapping route names to their respective types
            var pageRoutes = new Dictionary<string, Type>();

            // Loop through types in the assembly to find view pages and map them to their routes
            foreach (var item in assembly.GetTypes()) {
                // Check if the type belongs to the specified view namespace and ends with a defined "Page" suffix
                if (item.Namespace == viewNamespace && item.Name.EndsWith(Constants.PAGE)) {
                    // Get the route name from the type's name
                    var routeName = item.Name;

                    // Add the route name and its associated type to the dictionary
                    pageRoutes.Add(routeName, item);
                }
            }

            // Register each discovered route in the application's routing system
            foreach (var kvp in pageRoutes) {
                // Register the route using its name and associated type
                Routing.RegisterRoute(kvp.Key, kvp.Value);
            }

        }
    }
}
