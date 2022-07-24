namespace WitchSaga.Application.Services
{
    public class ServiceResponse<T> : ResponseBase
    {
        public T Result { get; set; }
    }
}
