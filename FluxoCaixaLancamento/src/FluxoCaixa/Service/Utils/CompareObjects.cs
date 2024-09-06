namespace FluxoCaixa.Service.Utils
{
    public static class CompareObjects
    {
        public static IEnumerable<KeyValuePair<string, object>> Compare<T>(this T obj, T modifiedObject)
        {
            foreach (var property in typeof(T).GetProperties().Where(p => !p.GetGetMethod().IsVirtual))
            {
                if (property.GetValue(modifiedObject) != null 
                    && property.GetValue(obj).ToString() != property.GetValue(modifiedObject).ToString())
                {
                    yield return new KeyValuePair<string, object>(property.Name, property.GetValue(modifiedObject));
                }
            }
        }
    }
}
