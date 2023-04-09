namespace BLL.Entities
{
    public class Result<T> : EmptyResult
    {
        public T Data { get; set; }
    }
}
