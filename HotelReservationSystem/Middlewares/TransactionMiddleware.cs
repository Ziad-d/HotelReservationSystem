using HotelReservationSystem.Data;

namespace ExaminationSystem.Middlewares
{
    public class TransactionMiddleware
    {
        RequestDelegate _next;
        Context _context;

        public TransactionMiddleware(RequestDelegate next, Context context)
        {
            _next = next;
            _context = context;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            var method = httpContext.Request.Method.ToUpper();
            if (method == "POST" || method == "PUT" || method == "DELETE")
            {
                var transaction = _context.Database.BeginTransaction();

                try
                {
                    await _next(httpContext);
                    _context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    throw;
                }
            }
            else
            {
                await _next(httpContext);
            }
        }
    }
}
