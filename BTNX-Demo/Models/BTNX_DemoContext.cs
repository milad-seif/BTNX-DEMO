using System.Data.Entity;

namespace BTNX_Demo.Models
{
    public class BTNX_DemoContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<BTNX_Demo.Models.BTNX_DemoContext>());

        public BTNX_DemoContext() : base("name=BTNX_DemoContext")
        {
        }

        public DbSet<Job_Seeker_Questionnaire> Job_Seeker_Questionnaire { get; set; }
    }
}
