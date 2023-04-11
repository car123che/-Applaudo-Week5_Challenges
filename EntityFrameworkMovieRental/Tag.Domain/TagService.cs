using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFUnivestityRentalData;
using Microsoft.EntityFrameworkCore;

namespace Tag.Domain
{
    public interface ITagService
    {
        Task<EFMovieRentalDomain.Tag> Post(string Name);
        Task<List<EFMovieRentalDomain.Tag>> Get();
        Task<EFMovieRentalDomain.Tag> Get(int Id);
        Task<string> Delete(int Id);
        Task<string> Update(int Id, string newName);
    }

    public class TagService : ITagService
    {
        private static MovieRentalContext context = new MovieRentalContext();
        public async Task<List<EFMovieRentalDomain.Tag>> Get()
        {
            var tags = await context.Tags.ToListAsync();
            return tags;
        }
        public async Task<EFMovieRentalDomain.Tag> Get(int Id)
        {
            var tag = await context.Tags.FindAsync(Id);
            return tag;
        }
        public async Task<EFMovieRentalDomain.Tag> Post(string Name)
        {
            var tag = new EFMovieRentalDomain.Tag() { Name = Name };
            await context.AddAsync(tag);

            await context.SaveChangesAsync();

            return tag;
        }
        public async Task<string> Delete(int Id)
        {
            var tag = await context.Tags.FindAsync(Id);
            context.Tags.Remove(tag);
            await context.SaveChangesAsync();

            return $"Tag: {tag.Name} - eliminada";
        }
        public async Task<string> Update(int Id, string newName)
        {
            var tag = await context.Tags.FindAsync(Id);
            tag.Name = newName;
            await context.SaveChangesAsync();

            return $"Tag modificada correctamente";
        }

    }
}
