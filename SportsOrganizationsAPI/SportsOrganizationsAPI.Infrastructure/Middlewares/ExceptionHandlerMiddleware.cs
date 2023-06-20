using Microsoft.AspNetCore.Http;
using SportsOrganizationsAPI.Persistence.Exceptions;

namespace SportsOrganizationsAPI.Infrastructure.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionMessageAsync(context, ex).ConfigureAwait(false);
            }
        }

        private static Task HandleExceptionMessageAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "text/plain;charset=utf-8";

            /// 400 - некорректный, не полный или пустой запрос (например, если в 
            ///       JSON не был передан какой то параметр)
            /// 404 - страница или элемент не найден (например, если неверно 
            ///       указан ID)
            /// 409 - конфликт при выполнении запроса (например, если человека 
            ///       пытаются добавить в клуб, а он уже состоит в клубе)   

            try
            {
                throw exception;
            }
            catch (ElementNotFoundException)
            {
                return CreateError(context, 404, exception);
            }
            catch (Exception ex)
            {
                var a = ex.GetType();
                return CreateError(context, 403, $"Неизвестная ошибка\n\n{ex.Message}");
            }
        }

        /// <summary>
        /// Создать ошибку
        /// </summary>
        /// <remarks>
        /// Вынос повторяющейся информации
        /// </remarks>
        /// <param name="context">HttpContext</param>
        /// <param name="statusCode">Статус код</param>
        /// <param name="message">Сообщение</param>
        /// <returns></returns>
        private static Task CreateError(HttpContext context, int statusCode, string message)
        {
            context.Response.StatusCode = statusCode;
            return context.Response.WriteAsync(message);
        }

        /// <summary>
        /// Создать ошибку
        /// </summary>
        /// <remarks>
        /// Вынос повторяющейся информации
        /// </remarks>
        /// <param name="context">HttpContext</param>
        /// <param name="statusCode">Статус код</param>
        /// <param name="exception">Возникшая ошибка</param>
        /// <returns></returns>
        private static Task CreateError(HttpContext context, int statusCode, Exception exception)
        {
            return CreateError(context, statusCode, exception.Message);
        }
    }
}