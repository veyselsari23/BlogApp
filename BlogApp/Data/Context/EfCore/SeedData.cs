using System.Net.Mime;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Context.EfCore
{





    public static class SeedData
    {


        public static void TestVerileriniDoldur(IApplicationBuilder app)
        {

            // Application bize parametre olarak gelir . ve onun üzerinden servislere ulaşırız
            // Servis üzerinden de context e ulaşırız
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<DataContext>();

            // Eğer Context Null değilse 
            if (context != null)
            {

                // Uygulamada Migration Oluşturulmuş ancak uygulanmış bir migration yoksa 
                if (context.Database.GetPendingMigrations().Any())
                {

                    // migration u migrate ediyoruz 
                    // şimdi test datalarını tablolara ekleyelim.
                    context.Database.Migrate();
                }

                // Tags Tablosuna Veriler Ekleyelim.
                // Eğer Tags. Tablosunda hiç veri yoksa
                if (context.Tags.Any())
                {

                    context.Tags.AddRange(
                        new Entity.Tag { Text = "Web Programlama" },
                        new Entity.Tag { Text = "backend" },
                        new Entity.Tag { Text = "frontend" },
                        new Entity.Tag { Text = "fullstack" },
                        new Entity.Tag { Text = "Php" }
                        );

                }

                // Burada Anladığım Şöyle bir mantık var . 
                // Biz Foreign Keylerle bir bağlantımız var (Default Convention Mantığı ile )
                // Dolayısıyla Verileri eklerken bu mantığa uygun öncelik vermemiz gerekiyor 

                // Eğer User Tablosunda hiç veri yoksa
                if(context.Users.Any()){
                    context.Users.AddRange(
                        new Entity.User { UserName = "veyselsari23"},
                        new Entity.User { UserName = "ahmetyilmaz"}
                    );

                }

                // Şimdi Eğer Post Yoksa Post Ekleyelim. Comment i önce ekleyemiyorum 
                // Çünkü bir PostId si oluşmamışsa herhangi bir comment ekleyemem
                //Comment i sonra arayüzden seçip uygulayacağız

              if(!context.Posts.Any()){

                    context.Posts.AddRange(

                            new Entity.Post { Title="Asp.net Core ",
                            PostContent="Asp.Net Core Dersleri",
                            IsActive=true,
                            PublishedOn=DateTime.Now.AddDays(-10),
                            Tags=context.Tags.Take(3).ToList(),
                            UserId=1
                            },
                             new Entity.Post { Title="Asp.net Core ",
                            PostContent="Asp.Net Core Dersleri",
                            IsActive=true,
                            PublishedOn=DateTime.Now.AddDays(-10),
                            Tags=context.Tags.Take(3).ToList(),
                            UserId=1
                            },
                             new Entity.Post { Title="Asp.net Core ",
                            PostContent="Asp.Net Core Dersleri",
                            IsActive=true,
                            PublishedOn=DateTime.Now.AddDays(-10),
                            Tags=context.Tags.Take(3).ToList(),
                            UserId=2
                            },
                             new Entity.Post { Title="Asp.net Core ",
                            PostContent="Asp.Net Core Dersleri",
                            IsActive=true,
                            PublishedOn=DateTime.Now.AddDays(-10),
                            Tags=context.Tags.Take(3).ToList(),
                            UserId=2
                            }


                    );


                    context.SaveChanges();            
                    

                }   



            }

        }



    }
}