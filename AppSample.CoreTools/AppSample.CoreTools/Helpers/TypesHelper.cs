namespace AppSample.CoreTools.Helpers;

public static class TypesHelper
{
    /// <summary>
    /// Получение списка всех наследников типа в коде сборок AppSample.*
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IEnumerable<Type> GetAllDescendantsInAppSampleAssemblies<T>() where T : class
    {
        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            var name = assembly.GetName().Name;
            if (name != null && name.StartsWith("AppSample.", StringComparison.OrdinalIgnoreCase))
            {
                foreach (var type in assembly.GetTypes()
                             .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(T))))
                {
                    yield return type;
                }
            }
        }
    }
}