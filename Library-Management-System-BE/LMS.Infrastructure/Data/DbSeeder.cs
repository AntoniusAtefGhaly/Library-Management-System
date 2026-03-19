using LMS.Domain.Entities;
using LMS.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace LMS.Infrastructure.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAdminAsync(UserManager<User> userManager)
        {
            try
            {
                // ?? Ensure admin user exists
                string adminEmail = "admin@lms.com";
                string adminPassword = "Pass@123"; // ?? Change in production

                var adminUser = await userManager.FindByEmailAsync(adminEmail);
                if (adminUser == null)
                {
                    var newAdmin = new User
                    {
                        Email = adminEmail.Trim(),
                        FirstName = "Admin",
                        LastName = "User",
                        UserName = adminEmail,
                        PhoneNumber = "000000000000",
                        Role = "Admin",
                        InsertedTime = DateTime.Now,
                        IsActive = true,
                        EmailConfirmed = true
                    };

                    var createUserResult = await userManager.CreateAsync(newAdmin, adminPassword);
                    if (!createUserResult.Succeeded)
                    {
                        throw new Exception($"Failed to create admin user: {string.Join(", ", createUserResult.Errors.Select(e => e.Description))}");
                    }

                    // ? Assign Claims
                    List<Claim> claims = new()
                    {
                        new Claim(ClaimTypes.NameIdentifier, newAdmin.Id.ToString()),
                        new Claim(ClaimTypes.Email, newAdmin.Email.ToString()),
                        new Claim(ClaimTypes.Role, newAdmin.Role.ToString()),
                    };

                    var claimsResult = await userManager.AddClaimsAsync(newAdmin, claims);
                    if (!claimsResult.Succeeded)
                    {
                        throw new Exception($"Failed to add claims: {string.Join(", ", claimsResult.Errors.Select(e => e.Description))}");
                    }

                    Console.WriteLine("? Admin user created successfully.");
                }
                else
                {
                    Console.WriteLine("?? Admin user already exists.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"? Error seeding admin user: {ex.Message}");
            }
        }

        public static async Task SeedLibrarianAsync(UserManager<User> userManager)
        {
            try
            {
                // ?? Ensure librarian user exists
                string librarianEmail = "Librarian@lms.com";
                string librarianPassword = "Pass@123";

                var librarianUser = await userManager.FindByEmailAsync(librarianEmail);
                if (librarianUser == null)
                {
                    var newLibrarian = new User
                    {
                        Email = librarianEmail.Trim(),
                        FirstName = "Librarian",
                        LastName = "User",
                        UserName = librarianEmail,
                        PhoneNumber = "000000000000",
                        Role = "Librarian",
                        InsertedTime = DateTime.Now,
                        IsActive = true,
                        EmailConfirmed = true
                    };

                    var createUserResult = await userManager.CreateAsync(newLibrarian, librarianPassword);
                    if (!createUserResult.Succeeded)
                    {
                        throw new Exception($"Failed to create librarian user: {string.Join(", ", createUserResult.Errors.Select(e => e.Description))}");
                    }

                    // ? Assign Claims
                    List<Claim> claims = new()
                    {
                        new Claim(ClaimTypes.NameIdentifier, newLibrarian.Id.ToString()),
                        new Claim(ClaimTypes.Email, newLibrarian.Email.ToString()),
                        new Claim(ClaimTypes.Role, newLibrarian.Role.ToString()),
                    };

                    var claimsResult = await userManager.AddClaimsAsync(newLibrarian, claims);
                    if (!claimsResult.Succeeded)
                    {
                        throw new Exception($"Failed to add claims: {string.Join(", ", claimsResult.Errors.Select(e => e.Description))}");
                    }

                    Console.WriteLine("? Librarian user created successfully.");
                }
                else
                {
                    Console.WriteLine("?? Librarian user already exists.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"? Error seeding librarian user: {ex.Message}");
            }
        }

        public static async Task SeedMembersAsync(UserManager<User> userManager)
        {
            try
            {
                var members = new List<(string Email, string FirstName, string LastName)>
                {
                    ("ahmedhamdisaeed@gmail.com", "ahmed", "hamdi saeed"),
                    ("antonius.a.ghaly@gmail.com", "Antonius", "Ghaly"),
                    ("mahmoud.ahmed.pro4@gmail.com", "mahmoud", "ahmed"),
                    ("mahmoudxkhaled@gmail.com", "mahmoud", "khaled")
                };

                string defaultPassword = "Pass@123";

                foreach (var member in members)
                {
                    var existingUser = await userManager.FindByEmailAsync(member.Email);
                    if (existingUser == null)
                    {
                        var newMember = new User
                        {
                            Email = member.Email.Trim(),
                            FirstName = member.FirstName.Trim(),
                            LastName = member.LastName.Trim(),
                            UserName = member.Email,
                            PhoneNumber = "000000000000",
                            Role = "Member",
                            InsertedTime = DateTime.Now,
                            IsActive = true,
                            EmailConfirmed = true
                        };

                        var createUserResult = await userManager.CreateAsync(newMember, defaultPassword);
                        if (!createUserResult.Succeeded)
                        {
                            Console.WriteLine($"Failed to create member {member.Email}: {string.Join(", ", createUserResult.Errors.Select(e => e.Description))}");
                            continue;
                        }

                        // ? Assign Claims
                        List<Claim> claims = new()
                        {
                            new Claim(ClaimTypes.NameIdentifier, newMember.Id.ToString()),
                            new Claim(ClaimTypes.Email, newMember.Email.ToString()),
                            new Claim(ClaimTypes.Role, newMember.Role.ToString()),
                        };

                        var claimsResult = await userManager.AddClaimsAsync(newMember, claims);
                        if (!claimsResult.Succeeded)
                        {
                            Console.WriteLine($"Failed to add claims for {member.Email}: {string.Join(", ", claimsResult.Errors.Select(e => e.Description))}");
                            continue;
                        }

                        Console.WriteLine($"? Member user {member.Email} created successfully.");
                    }
                    else
                    {
                        Console.WriteLine($"?? Member user {member.Email} already exists.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"? Error seeding member users: {ex.Message}");
            }
        }

        private static Transaction CreateRandomTransaction(int userId, int bookId, Random random)
        {
            var requestDate = DateTime.Now.AddDays(-random.Next(1, 60));
            var borrowDays = random.Next(7, 15);
            var statuses = new[] { "Pending", "Issued", "Pending", "Issued"/*, "Returned", "Overdue" */};
            var status = statuses[random.Next(statuses.Length)];

            DateTime? issueDate = null;
            DateTime? dueDate = null;
            DateTime? returnDate = null;

            if (status == "Pending")
            {
                // Pending transactions only have request date and borrow days
                issueDate = null;
                dueDate = null;
                returnDate = null;
            }
            else
            {
                // For Issued, Returned, and Overdue, we need issue date and due date
                issueDate = requestDate.AddDays(random.Next(1, 3));
                dueDate = issueDate.Value.AddDays(borrowDays);

                if (status == "Returned")
                {
                    // Returned transactions have all dates
                    returnDate = issueDate.Value.AddDays(random.Next(1, borrowDays));
                }
                else if (status == "Overdue")
                {
                    // Overdue transactions have issue date and due date in the past
                    issueDate = DateTime.Now.AddDays(-random.Next(borrowDays + 5, borrowDays + 15));
                    dueDate = issueDate.Value.AddDays(borrowDays);
                    returnDate = null;
                }
            }

            return new Transaction
            {
                UserId = userId,
                BookId = bookId,
                RequestDate = requestDate,
                IssueDate = issueDate,
                DueDate = dueDate,
                ReturnDate = returnDate,
                Status = status,
                BorrowDays = borrowDays,
                InsertedTime = DateTime.Now,
                IsActive = true
            };
        }

        public static async Task SeedTransactionsAsync(IUnitOfWork unitOfWork)
        {
            try
            {
                var members = await unitOfWork.UserRepository.GetWhereAsync(u => u.Role == "Member" && u.Email.Contains("gmail.com"));
                var books = await unitOfWork.BookRepository.GetAllAsync();
                var random = new Random();

                foreach (var member in members)
                {
                    int transactionCount = random.Next(5, 10);
                    for (int i = 0; i < transactionCount; i++)
                    {
                        var randomBook = books.ElementAt(random.Next(books.Count()));
                        var transaction = CreateRandomTransaction(member.Id, randomBook.Id, random);
                        await unitOfWork.TransactionRepository.AddAsync(transaction);
                    }
                }

                await unitOfWork.SaveChangesAsync();
                Console.WriteLine("? Transactions seeded successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"? Error seeding transactions: {ex.Message}");
            }
        }

        public static async Task SeedUsersWithTransactionsAsync(UserManager<User> userManager, IUnitOfWork unitOfWork, int numberOfUsers)
        {
            try
            {
                var random = new Random();
                var books = await unitOfWork.BookRepository.GetAllAsync();
                var defaultPassword = "Pass@123";

                var firstNames = new[] { "Ahmed", "Mohamed", "Ali", "Youssef", "Omar", "Mostafa", "Hassan", "Mahmoud", "Khaled", "Ibrahim" };
                var lastNames = new[] { "Hussein", "Farag", "Salah", "Saad", "Abdelrahman", "Tawfik", "Hamdy", "Gamal", "Nasser", "Zaki" };

                for (int i = 1; i <= numberOfUsers; i++)
                {
                    string email = $"user{i}@lms.com";
                    var existingUser = await userManager.FindByEmailAsync(email);

                    if (existingUser == null)
                    {
                        var firstNameIndex = (i - 1) % firstNames.Length;
                        var lastNameIndex = (i - 1) % lastNames.Length;

                        var newUser = new User
                        {
                            Email = email,
                            FirstName = firstNames[firstNameIndex],
                            LastName = lastNames[lastNameIndex],
                            UserName = email,
                            PhoneNumber = "000000000000",
                            Role = "Member",
                            InsertedTime = DateTime.Now,
                            IsActive = true,
                            EmailConfirmed = true
                        };

                        var createUserResult = await userManager.CreateAsync(newUser, defaultPassword);
                        if (!createUserResult.Succeeded)
                        {
                            Console.WriteLine($"Failed to create user {email}: {string.Join(", ", createUserResult.Errors.Select(e => e.Description))}");
                            continue;
                        }

                        List<Claim> claims = new()
                        {
                            new Claim(ClaimTypes.NameIdentifier, newUser.Id.ToString()),
                            new Claim(ClaimTypes.Email, newUser.Email.ToString()),
                            new Claim(ClaimTypes.Role, newUser.Role.ToString()),
                        };

                        var claimsResult = await userManager.AddClaimsAsync(newUser, claims);
                        if (!claimsResult.Succeeded)
                        {
                            Console.WriteLine($"Failed to add claims for {email}: {string.Join(", ", claimsResult.Errors.Select(e => e.Description))}");
                            continue;
                        }

                        int transactionCount = random.Next(1, 6);
                        for (int j = 0; j < transactionCount; j++)
                        {
                            var randomBook = books.ElementAt(random.Next(books.Count()));
                            var transaction = CreateRandomTransaction(newUser.Id, randomBook.Id, random);
                            await unitOfWork.TransactionRepository.AddAsync(transaction);
                        }
                    }
                }

                await unitOfWork.SaveChangesAsync();
                Console.WriteLine("? Users with transactions seeded successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"? Error seeding users with transactions: {ex.Message}");
            }
        }
    }
}
