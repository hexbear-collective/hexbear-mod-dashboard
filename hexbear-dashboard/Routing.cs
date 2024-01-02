
using Hexbear.Lib.EFCore;
using Hexbear.Lib.Services;
namespace hexbear_dashboard
{
    public static class Routing
    {

        public static void Route(WebApplication app)
        {
            app.MapGet("/api/ListUsers", async (LemmyContext db) =>
            {
                var service = new UserService();
                var result = await service.ListUsers(db);
                return result;
            });
            app.MapGet("/api/u/{username}", async (string username,LemmyContext db) =>
            {
                var service = new UserService();
                var result = await service.GetUserByName(db, username);
                if (result == null)
                    return Results.NotFound();
                
                return Results.Ok(result);
            });
            app.MapGet("/api/ListReports", async (LemmyContext db) =>
            {
                var service = new ReportService();
                var result = await service.ListReports(db);
                return result;
            });
            app.MapGet("/api/ListLogs", async () =>
            {
                var service = new LogService();
                var result = await service.ListLogs();
                return result;
            });
            app.MapGet("/api/comment/{id}", async (int id, LemmyContext db) =>
            {
                var service = new PostService();
                var result = await service.GetCommentDetails(id, db);
                if (result.Comment == null)
                    return Results.NotFound();

                return Results.Ok(result);
            });
            app.MapGet("/api/post/{id}", async (int id, LemmyContext db) =>
            {
                var service = new PostService();
                var result = await service.GetPostDetails(id, db);
                if (result.Post == null)
                    return Results.NotFound();

                return Results.Ok(result);
            });
        }
    }
}
