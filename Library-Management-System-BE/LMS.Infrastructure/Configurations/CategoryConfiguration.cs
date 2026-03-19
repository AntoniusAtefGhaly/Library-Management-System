using LMS.Domain.Entities;
using LMS.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace YourNamespace
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category { Id = 1, Name = "Fiction", Description = "Books that contain stories created from the imagination.", IsActive = true, IsDeleted = false },
                new Category { Id = 2, Name = "Non-Fiction", Description = "Books based on real facts and events.", IsActive = true, IsDeleted = false },
                new Category { Id = 3, Name = "Science", Description = "Books related to scientific principles, experiments, and discoveries.", IsActive = true, IsDeleted = false },
                new Category { Id = 4, Name = "Mathematics", Description = "Books covering mathematical theories, problems, and equations.", IsActive = true, IsDeleted = false },
                new Category { Id = 5, Name = "History", Description = "Books that discuss past events and historical occurrences.", IsActive = true, IsDeleted = false },
                new Category { Id = 6, Name = "Biography", Description = "Books about the lives of individuals, either famous or historical.", IsActive = true, IsDeleted = false },
                new Category { Id = 7, Name = "Literature", Description = "Books considered to have artistic value, including poetry, novels, and drama.", IsActive = true, IsDeleted = false },
                new Category { Id = 8, Name = "Philosophy", Description = "Books that explore fundamental questions about existence, knowledge, and ethics.", IsActive = true, IsDeleted = false },
                new Category { Id = 9, Name = "Psychology", Description = "Books related to human behavior, emotions, and cognitive functions.", IsActive = true, IsDeleted = false },
                new Category { Id = 10, Name = "Self-Help", Description = "Books that provide advice or strategies for improving life and personal growth.", IsActive = true, IsDeleted = false },
                new Category { Id = 11, Name = "Art", Description = "Books that focus on various forms of art, including visual arts, sculpture, and performance.", IsActive = true, IsDeleted = false },
                new Category { Id = 12, Name = "Music", Description = "Books that discuss musical theory, history, and performance techniques.", IsActive = true, IsDeleted = false },
                new Category { Id = 13, Name = "Health & Fitness", Description = "Books focused on physical well-being, exercise, and mental health.", IsActive = true, IsDeleted = false },
                new Category { Id = 14, Name = "Cooking", Description = "Books providing recipes and cooking techniques.", IsActive = true, IsDeleted = false },
                new Category { Id = 15, Name = "Travel", Description = "Books that explore destinations, cultures, and experiences in different parts of the world.", IsActive = true, IsDeleted = false },
                 new Category { Id = 16, Name = "Children's Books", Description = "Books intended for young readers, including stories and educational books." },
            new Category { Id = 17, Name = "Fantasy", Description = "Books containing magical or fantastical elements set in imaginary worlds." },
            new Category { Id = 18, Name = "Science Fiction", Description = "Books set in the future or in space, often incorporating advanced technology or extraterrestrial life." },
            new Category { Id = 19, Name = "Mystery", Description = "Books centered around solving a crime or uncovering secrets." },
            new Category { Id = 20, Name = "Thriller", Description = "Books designed to keep the reader on edge with suspense and tension." },
            new Category { Id = 21, Name = "Horror", Description = "Books designed to evoke fear or unease in the reader." },
            new Category { Id = 22, Name = "Poetry", Description = "Books containing poems, written in verse." },
            new Category { Id = 23, Name = "Religion", Description = "Books focused on religious studies, scriptures, and beliefs." },
            new Category { Id = 24, Name = "Spirituality", Description = "Books that explore personal growth and the search for meaning beyond the material world." },
            new Category { Id = 25, Name = "Politics", Description = "Books that explore political theory, history, and analysis." },

              new Category { Id = 26, Name = "Economics", Description = "Books about the production, distribution, and consumption of goods and services." },
            new Category { Id = 27, Name = "Business", Description = "Books on management, entrepreneurship, and business strategies." },
            new Category { Id = 28, Name = "Technology", Description = "Books covering advancements in technology, including programming, artificial intelligence, and gadgets." },
            new Category { Id = 29, Name = "Engineering", Description = "Books on engineering principles, innovations, and applications." },
            new Category { Id = 30, Name = "Law", Description = "Books about legal studies, statutes, and legal principles." },
            new Category { Id = 31, Name = "Photography", Description = "Books about the art and techniques of photography." },
            new Category { Id = 32, Name = "Architecture", Description = "Books on the design and construction of buildings and other structures." },
            new Category { Id = 33, Name = "Sports", Description = "Books about various sports, athletes, and sporting events." },
            new Category { Id = 34, Name = "Environment", Description = "Books focused on ecology, nature conservation, and environmental science." },
            new Category { Id = 35, Name = "Urban Studies", Description = "Books about cities, urban planning, and metropolitan life." },
            new Category { Id = 36, Name = "Economics & Finance", Description = "Books related to financial markets, investment strategies, and economic theory." },
            new Category { Id = 37, Name = "Parenting", Description = "Books offering advice for raising children and family dynamics." },
            new Category { Id = 38, Name = "Education", Description = "Books on educational methods, theories, and teaching practices." },
            new Category { Id = 39, Name = "Comic Books", Description = "Books consisting of illustrated stories in a comic strip format." },
            new Category { Id = 40, Name = "Graphic Novels", Description = "Books that combine illustrations with narrative storytelling, typically in a longer form." },
            new Category { Id = 41, Name = "Social Sciences", Description = "Books covering sociology, anthropology, and other social studies disciplines." },
            new Category { Id = 42, Name = "Linguistics", Description = "Books related to the scientific study of language and its structure." },
            new Category { Id = 43, Name = "Geography", Description = "Books about physical geography, the study of places and environments." },
            new Category { Id = 44, Name = "Space & Astronomy", Description = "Books about space exploration, the universe, stars, and planets." },
            new Category { Id = 45, Name = "Mathematical Fiction", Description = "Books that incorporate mathematical themes or problems in their stories." },
            new Category { Id = 46, Name = "Antiques & Collectibles", Description = "Books about the history and collection of valuable items." },
            new Category { Id = 47, Name = "Crafts & Hobbies", Description = "Books about various crafts, from knitting to woodworking." },
            new Category { Id = 48, Name = "Gardening", Description = "Books about planting, cultivating, and maintaining gardens." },
            new Category { Id = 49, Name = "Personal Finance", Description = "Books that focus on managing personal wealth, budgeting, and investing." },
            new Category { Id = 50, Name = "True Crime", Description = "Books that explore real-life criminal cases and investigations." }

            );
        }
    }
}
