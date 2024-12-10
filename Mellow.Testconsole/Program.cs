using Mellow.DAL.DbContexts;
using Mellow.DAL.GenericRepository.Abstract;
using Mellow.DAL.GenericRepository.Concrete;
using Mellow.Entites.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using System.Net.Mime;

namespace Mellow.Testconsole
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            AppDbcontext context = new AppDbcontext();
         
            IRepository<Oda> repository = new Repository<Oda>(context);

            var oda = await repository.GetAllAsync(default, x => x.OdaNumarasi == 102);
            Console.WriteLine(oda.FirstOrDefault().Id);
            //Oda oda = new Oda()
            //{
            //    OdaNumarasi = 101,
            //    OdaTipi = OdaTipi.Ekonomi,
            //    YatakSayisi = 1,
            //    IsReserved = false

            //};
            //var oda  = context.Odalar.First();
            //oda.OdaNumarasi = 102;

          
            //context.Odalar.Update(oda);
            //context.SaveChanges();
            Console.WriteLine("Hello, World!");
        }
    }
}
