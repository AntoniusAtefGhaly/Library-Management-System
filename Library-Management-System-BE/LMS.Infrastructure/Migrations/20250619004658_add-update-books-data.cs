using LMS.Domain.Entities;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addupdatebooksdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Set in the opulent backdrop of the Roaring Twenties, 'The Great Gatsby' tells the story of Jay Gatsby, a mysterious millionaire obsessed with reuniting with his lost love, Daisy Buchanan. Narrated by Nick Carraway, the novel explores the illusions of wealth and the corruption of the American Dream. Through lavish parties and tragic romance, it portrays a society enthralled by materialism and status, yet hollow beneath the glittering surface. F. Scott Fitzgerald crafts a timeless reflection on desire, disillusionment, and the fragile nature of dreams.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Set in the racially segregated American South during the 1930s, 'To Kill a Mockingbird' follows young Scout Finch as she navigates childhood in a deeply divided society. When her father, Atticus Finch, defends a Black man falsely accused of raping a white woman, Scout and her brother Jem are exposed to the harsh realities of prejudice and injustice. Through innocence, courage, and moral growth, Harper Lee's novel powerfully addresses issues of race, empathy, and ethical integrity in a small Alabama town.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "In 'Sapiens: A Brief History of Humankind,' Yuval Noah Harari chronicles the journey of Homo sapiens from primitive hunter-gatherers to modern global citizens. Through a multidisciplinary lens that includes biology, anthropology, and economics, the book explores major revolutions—cognitive, agricultural, industrial, and technological—that have shaped human society. Harari challenges readers to reconsider assumptions about history, culture, and the future, offering deep insights into the forces that have governed our development and what it truly means to be human.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "'Educated' is Tara Westover's compelling memoir of resilience and transformation. Born to survivalist parents in rural Idaho, she grows up without formal education and is subjected to physical and emotional hardship. Despite the odds, she teaches herself enough to attend college and eventually earns a PhD from Cambridge University. Her journey is a testament to the power of education, personal determination, and the courage it takes to question one's upbringing while seeking truth, growth, and a life of one's own making.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "In 'A Brief History of Time,' renowned physicist Stephen Hawking invites readers into the mysterious world of cosmology. Exploring topics such as black holes, the Big Bang, and quantum mechanics, the book simplifies complex concepts while tackling profound questions about the universe's origin, structure, and fate. Hawking's accessible writing and wit help demystify science, making it engaging for the general audience. The book remains a landmark work that inspires curiosity about the cosmos and our place within it.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 21,
                column: "Description",
                value: "E.H. Gombrich's 'The Story of Art' stands as one of the most accessible and comprehensive introductions to art history ever written. Spanning from prehistoric cave paintings to modern masterpieces, the book presents art as a continuous narrative of human creativity and expression. Gombrich's engaging writing style makes complex artistic movements and techniques understandable to readers of all backgrounds. The book explores how art reflects cultural values, technological advances, and human emotions across different periods and civilizations, offering readers a profound appreciation for the visual arts and their enduring impact on society.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 22,
                column: "Description",
                value: "John Berger's revolutionary 'Ways of Seeing' challenges conventional approaches to art appreciation and visual culture. Through a series of essays, Berger examines how we perceive and interpret images, questioning the assumptions behind traditional art criticism. The book explores themes of gender, class, and power in visual representation, revealing how images can reinforce or challenge social hierarchies. Berger's Marxist perspective offers readers new tools for analyzing not just fine art, but advertising, photography, and mass media, making this work essential for understanding the politics of visual culture in modern society.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 23,
                column: "Description",
                value: "Alex Ross's 'The Rest Is Noise' offers a sweeping history of 20th-century classical music, exploring how composers responded to the tumultuous events of their time. From the rise of modernism to the impact of war and political upheaval, Ross traces the evolution of musical styles and the lives of influential composers. The book examines how music reflected and influenced social change, from the avant-garde experiments of Stravinsky to the minimalist movements of the late century. Ross's engaging narrative makes complex musical concepts accessible while revealing the profound connections between art, politics, and human experience.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 24,
                column: "Description",
                value: "David Byrne's 'How Music Works' is a fascinating exploration of music from multiple perspectives: as a cultural phenomenon, a technological medium, and a fundamental human expression. Drawing on his experience as a musician and his curiosity about different musical traditions, Byrne examines how music is created, performed, and experienced across various contexts. The book covers topics ranging from the physics of sound to the economics of the music industry, from ancient musical traditions to digital innovations. Byrne's insights offer readers a deeper understanding of how music shapes our lives and connects us across cultures and generations.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 25,
                column: "Description",
                value: "Bessel van der Kolk's groundbreaking work 'The Body Keeps the Score' revolutionizes our understanding of trauma and its profound effects on the brain, mind, and body. Drawing on decades of research and clinical experience, van der Kolk explains how traumatic experiences can alter brain chemistry and function, leading to lasting psychological and physical consequences. The book explores innovative treatment approaches, from traditional therapy to body-based interventions like yoga and neurofeedback. Van der Kolk's compassionate perspective offers hope for healing while providing essential insights for anyone affected by trauma or working with trauma survivors.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 26,
                column: "Description",
                value: "Christopher McDougall's 'Born to Run' combines adventure, science, and human potential in a compelling narrative about the art and science of running. The book follows McDougall's journey to discover the secrets of the Tarahumara, a remote Mexican tribe known for their extraordinary long-distance running abilities. Through their story, McDougall explores evolutionary biology, biomechanics, and the psychology of endurance, challenging conventional wisdom about running shoes, training methods, and human limitations. The book inspires readers to reconsider their relationship with physical activity and discover the joy of movement that lies within us all.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 27,
                column: "Description",
                value: "Irma S. Rombauer's 'The Joy of Cooking' has become an American culinary institution, serving as the definitive cookbook for generations of home cooks. First published during the Great Depression, the book has evolved through multiple editions while maintaining its practical approach to cooking. Rombauer's warm, encouraging voice and comprehensive coverage of techniques make complex recipes accessible to beginners while offering depth for experienced cooks. The book celebrates the joy of preparing food for loved ones, emphasizing the connection between cooking, family, and cultural heritage that makes this more than just a collection of recipes.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 28,
                column: "Description",
                value: "Samin Nosrat's 'Salt, Fat, Acid, Heat' revolutionizes how we think about cooking by focusing on the four fundamental elements that make food delicious. Rather than memorizing recipes, Nosrat teaches readers to understand the principles behind great cooking, empowering them to create flavorful dishes with confidence. The book combines scientific explanations with practical techniques, beautiful illustrations, and personal anecdotes that make learning to cook both educational and enjoyable. Nosrat's approach encourages experimentation and creativity, helping readers develop an intuitive understanding of how to balance flavors and create memorable meals.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 29,
                column: "Description",
                value: "Anthony Bourdain's 'Kitchen Confidential' pulls back the curtain on the culinary world, revealing the intense, chaotic, and often brutal reality behind restaurant kitchens. Bourdain's candid and sometimes controversial memoir exposes the passion, pressure, and personalities that drive the food industry. Through vivid storytelling and sharp wit, he shares the lessons learned from his years in professional kitchens, from the importance of proper knife skills to the unspoken rules of kitchen culture. The book offers readers an insider's perspective on the dedication and sacrifice required to create memorable dining experiences.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 30,
                column: "Description",
                value: "Michael Pollan's 'The Omnivore's Dilemma' investigates the complex web of choices involved in what we eat, tracing the journey of food from farm to table. Through four different meals, Pollan explores industrial agriculture, organic farming, hunting and gathering, and sustainable food systems. The book examines the environmental, ethical, and health implications of our food choices, challenging readers to consider the true cost of their meals. Pollan's engaging narrative style makes complex issues accessible while providing practical guidance for making more informed and responsible food decisions in our daily lives.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 31,
                column: "Description",
                value: "Stephen King's 'On Writing' is both a memoir and a masterclass in the craft of writing. King shares his personal journey from struggling writer to bestselling author, offering practical advice alongside intimate stories from his life. The book covers essential writing techniques, from developing characters and plot to handling rejection and finding your voice. King's honest, conversational style makes complex writing concepts accessible while providing inspiration for aspiring authors. This is more than a how-to guide—it's a testament to the power of persistence and the joy of storytelling.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 32,
                column: "Description",
                value: "Anne Lamott's 'Bird by Bird' offers a compassionate and humorous guide to the writing life, filled with practical wisdom and emotional support for writers at every stage. Lamott addresses the common fears and challenges that writers face, from perfectionism to writer's block, offering gentle encouragement and practical strategies. Through personal anecdotes and honest reflections, she explores the creative process, the importance of community, and the courage required to share your work. The book is both a writing manual and a meditation on the human condition, reminding readers that writing is ultimately about connection and truth.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 33,
                column: "Description",
                value: "William Strunk Jr. and E.B. White's 'The Elements of Style' remains the definitive guide to clear, effective writing. This concise manual covers the fundamental principles of composition, grammar, and style that every writer should master. From basic rules of usage to advanced techniques for creating compelling prose, the book provides practical examples and clear explanations. Its timeless advice on brevity, clarity, and precision has influenced generations of writers, making it an essential reference for students, professionals, and anyone who wants to communicate more effectively through the written word.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 34,
                column: "Description",
                value: "Steven Pressfield's 'The War of Art' identifies and confronts the internal obstacles that prevent creative people from achieving their potential. Pressfield personifies these barriers as 'Resistance,' a force that manifests as procrastination, self-doubt, and fear. The book provides strategies for recognizing and overcoming these creative blocks, emphasizing the importance of discipline, commitment, and professional approach to creative work. Pressfield's insights help readers understand that the struggle with resistance is universal and that the key to creative success lies in showing up and doing the work consistently.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 35,
                column: "Description",
                value: "Paulo Coelho's 'The Alchemist' follows the journey of Santiago, a young Andalusian shepherd who dreams of finding a worldly treasure. His quest takes him from Spain to Egypt, where he encounters various characters who teach him about life, love, and the pursuit of one's Personal Legend. The novel explores themes of destiny, faith, and the interconnectedness of all things, blending elements of magical realism with philosophical insights. Coelho's allegorical tale encourages readers to follow their dreams while recognizing that the journey itself often holds greater value than the destination.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 36,
                column: "Description",
                value: "George Orwell's '1984' presents a chilling vision of a totalitarian future where Big Brother watches every move and thought crime is punishable by death. The novel follows Winston Smith, a low-ranking member of the ruling Party who begins to question the oppressive regime. Through Winston's journey, Orwell explores themes of surveillance, propaganda, and the manipulation of truth and language. The book serves as a powerful warning about the dangers of unchecked government power and the importance of preserving individual freedom and critical thinking.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 37,
                column: "Description",
                value: "Aldous Huxley's 'Brave New World' envisions a future society where happiness is achieved through genetic engineering, psychological conditioning, and the use of a drug called soma. The novel explores the conflict between individual freedom and social stability, questioning whether true happiness can exist without suffering and choice. Through the character of John the Savage, who represents natural human emotions and spirituality, Huxley examines the price of a perfectly ordered society and the value of authentic human experience.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 38,
                column: "Description",
                value: "Ray Bradbury's 'Fahrenheit 451' depicts a future society where books are banned and burned by firemen, and critical thinking is discouraged. The novel follows Guy Montag, a fireman who begins to question his role in destroying knowledge and literature. Through Montag's transformation, Bradbury explores themes of censorship, the importance of literature and free thought, and the role of technology in shaping society. The book serves as a powerful reminder of the value of books and the dangers of intellectual suppression.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 39,
                column: "Description",
                value: "J.D. Salinger's 'The Catcher in the Rye' follows Holden Caulfield, a disenchanted teenager who has been expelled from prep school and wanders New York City for three days. Through Holden's first-person narrative, the novel explores themes of alienation, loss of innocence, and the transition from childhood to adulthood. Holden's cynical yet vulnerable voice captures the confusion and disillusionment of adolescence, making the novel a powerful exploration of teenage angst and the search for authenticity in a world that seems phony.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 40,
                column: "Description",
                value: "Margaret Atwood's 'The Handmaid's Tale' is set in a dystopian future where a totalitarian regime has overthrown the United States government and established a theocratic society. The novel follows Offred, a Handmaid whose sole purpose is to bear children for the ruling class. Through Offred's perspective, Atwood explores themes of gender oppression, reproductive rights, and the manipulation of religious ideology for political control. The novel serves as a powerful commentary on women's rights and the dangers of fundamentalism.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 41,
                column: "Description",
                value: "Cormac McCarthy's 'The Road' follows a father and son as they journey through a post-apocalyptic America, struggling to survive in a world devastated by an unspecified catastrophe. The novel explores themes of love, hope, and the human will to survive in the face of overwhelming despair. Through the father's determination to protect his son and the boy's innocence and compassion, McCarthy examines what it means to remain human in an inhumane world. The novel is a powerful meditation on the bond between parent and child and the resilience of the human spirit.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 42,
                column: "Description",
                value: "Kate Atkinson's 'Life After Life' follows Ursula Todd, who is born in 1910 and dies repeatedly, only to be reborn and live her life again with slight variations. Each iteration allows her to make different choices and experience different outcomes, exploring themes of fate, free will, and the impact of small decisions on the course of history. The novel examines how individual lives intersect with major historical events, particularly World War II, and questions whether we can truly change our destiny or if we are bound by predetermined paths.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 43,
                column: "Description",
                value: "Rick Yancey's 'The 5th Wave' is set in a world where Earth has been invaded by aliens who have systematically eliminated most of humanity through four waves of attacks. The novel follows Cassie Sullivan, a teenage girl trying to survive and find her younger brother. As she navigates a world where trust is impossible and survival requires constant vigilance, Cassie must determine who is truly human and who might be an alien in disguise. The novel explores themes of survival, trust, and the resilience of the human spirit in the face of overwhelming odds.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 44,
                column: "Description",
                value: "Suzanne Collins' 'The Hunger Games' is set in a dystopian future where the totalitarian nation of Panem forces children to participate in a televised fight to the death. The novel follows Katniss Everdeen, who volunteers to take her sister's place in the Games. Through Katniss's journey, Collins explores themes of survival, sacrifice, and the effects of violence on young people. The novel also examines the role of media in shaping public opinion and the power of individual resistance against oppressive systems.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 45,
                column: "Description",
                value: "Veronica Roth's 'Divergent' is set in a dystopian society divided into factions based on virtues. The novel follows Beatrice Prior, who discovers she is Divergent—someone who doesn't fit into any single faction. As she navigates the dangerous initiation process for her chosen faction, Beatrice must hide her Divergence while uncovering a conspiracy that threatens the entire society. The novel explores themes of identity, choice, and the pressure to conform to societal expectations.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 46,
                column: "Description",
                value: "Paula Hawkins' 'The Girl on the Train' follows Rachel Watson, an alcoholic woman who becomes obsessed with a seemingly perfect couple she observes from her daily train commute. When the woman goes missing, Rachel becomes involved in the investigation, but her unreliable memory and drinking problem make her an unreliable witness. The novel explores themes of memory, perception, and the unreliability of human observation, while examining the consequences of addiction and the search for redemption.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 47,
                column: "Description",
                value: "Gillian Flynn's 'Gone Girl' tells the story of Nick and Amy Dunne, a married couple whose relationship has deteriorated. When Amy disappears on their fifth wedding anniversary, Nick becomes the prime suspect in her disappearance. The novel alternates between Nick's perspective and Amy's diary entries, creating a complex narrative that explores themes of marriage, media manipulation, and the construction of identity. Flynn examines how public perception can be shaped by media coverage and the ways in which people present different versions of themselves.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 48,
                column: "Description",
                value: "Gillian Flynn's 'Sharp Objects' follows Camille Preaker, a journalist who returns to her hometown to investigate the murders of two young girls. As Camille delves into the case, she must confront her own troubled past and the dysfunctional relationship with her mother and half-sister. The novel explores themes of family dysfunction, self-harm, and the lasting effects of childhood trauma. Flynn examines how the past can continue to influence the present and the ways in which people cope with pain and trauma.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 49,
                column: "Description",
                value: "Liane Moriarty's 'Big Little Lies' is set in a seemingly perfect coastal town where three women become friends while dealing with their own personal struggles. The novel explores themes of domestic violence, single parenthood, and the pressure to maintain appearances in a judgmental community. Through the perspectives of the three main characters, Moriarty examines the complexities of female friendships and the ways in which women support each other through difficult times. The novel also addresses the impact of social media and gossip on people's lives.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 50,
                column: "Description",
                value: "Stieg Larsson's 'The Girl with the Dragon Tattoo' follows journalist Mikael Blomkvist and computer hacker Lisbeth Salander as they investigate a decades-old disappearance. The novel explores themes of corruption, violence against women, and the power of investigative journalism. Through the character of Lisbeth Salander, Larsson examines issues of social justice and the ways in which society often fails to protect vulnerable individuals. The novel also addresses themes of revenge, redemption, and the search for truth in a world where powerful people can hide their crimes.");

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "ActivationTime", "ActivationUserId", "AuthorId", "AvailableCopies", "CategoryId", "DeletedTime", "DeletedUserId", "Description", "ImageUrl", "InsertedTime", "InsertedUserId", "IsActive", "IsDeleted", "IsTrending", "PublicationYear", "Title", "TotalCopies", "UpdateTime", "UpdateUserId" },
                values: new object[,]
                {
                    { 51, null, null, 1, 6, 1, null, null, "F. Scott Fitzgerald's 'Tender Is the Night' follows the glamorous lives of Dick and Nicole Diver, an American couple living in the French Riviera during the 1920s. The novel explores themes of wealth, mental illness, and the disintegration of relationships against the backdrop of post-war Europe. Through the character of Dick Diver, a promising psychiatrist whose life unravels, Fitzgerald examines the destructive power of privilege and the fragility of human connections.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 1934, "Tender Is the Night", 10, null, null },
                    { 52, null, null, 1, 5, 1, null, null, "F. Scott Fitzgerald's debut novel 'This Side of Paradise' follows Amory Blaine from his privileged childhood through his years at Princeton and into early adulthood. The novel captures the spirit of the Jazz Age and explores themes of love, ambition, and the search for identity. Through Amory's journey, Fitzgerald examines the disillusionment of a generation and the challenges of growing up in a rapidly changing world.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 1920, "This Side of Paradise", 8, null, null },
                    { 53, null, null, 2, 7, 1, null, null, "Harper Lee's 'Go Set a Watchman' follows an adult Scout Finch as she returns to Maycomb, Alabama, to visit her father Atticus. Set during the civil rights movement, the novel explores themes of racial tension, family relationships, and the complexity of moral choices. Through Scout's disillusionment with her father's views, Lee examines how individuals and communities grapple with social change and personal growth.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1430316106i/25388113.jpg", null, null, true, false, false, 2015, "Go Set a Watchman", 12, null, null },
                    { 54, null, null, 3, 8, 2, null, null, "Yuval Noah Harari's 'Homo Deus' explores the future of humanity, examining how technology and artificial intelligence might transform human society. The book discusses the potential for humans to become god-like through genetic engineering, artificial intelligence, and other technological advances. Harari challenges readers to consider what it means to be human in an age where we may transcend our biological limitations.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1468760805i/31138556.jpg", null, null, true, false, false, 2015, "Homo Deus: A Brief History of Tomorrow", 15, null, null },
                    { 55, null, null, 3, 10, 2, null, null, "Yuval Noah Harari's '21 Lessons for the 21st Century' addresses the most pressing issues facing humanity today, from technological disruption to political polarization. The book examines how artificial intelligence, climate change, and globalization are reshaping our world and challenges readers to think critically about the future. Harari provides insights into how individuals can navigate an increasingly complex and uncertain world.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1532974590i/41057292.jpg", null, null, true, false, false, 2018, "21 Lessons for the 21st Century", 18, null, null },
                    { 56, null, null, 5, 9, 3, null, null, "Stephen Hawking's 'The Universe in a Nutshell' explores the latest developments in theoretical physics, from string theory to the nature of time. The book uses accessible language and illustrations to explain complex concepts like quantum mechanics and the multiverse theory. Hawking examines how our understanding of the universe has evolved and what mysteries remain to be solved.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 2001, "The Universe in a Nutshell", 14, null, null },
                    { 57, null, null, 5, 7, 3, null, null, "Stephen Hawking and Leonard Mlodinow's 'The Grand Design' explores the fundamental questions about the universe and our place in it. The book discusses the latest theories in physics, including M-theory and the possibility of multiple universes. Through accessible explanations, the authors examine whether the universe needs a creator and how science might provide answers to the deepest questions about existence.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 2010, "The Grand Design", 12, null, null },
                    { 58, null, null, 6, 8, 2, null, null, "Richard Dawkins' 'The Blind Watchmaker' explains how natural selection can create complex biological structures without the need for a designer. The book uses clear examples and analogies to demonstrate how evolution works and why it produces such remarkable adaptations. Dawkins argues that the complexity of life can be explained by the cumulative effects of natural selection acting over vast periods of time.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 1986, "The Blind Watchmaker", 13, null, null },
                    { 59, null, null, 6, 12, 2, null, null, "Richard Dawkins' 'The God Delusion' presents a comprehensive argument against the existence of God and the value of religious belief. The book examines the evidence for and against religious claims, discusses the origins of religion, and explores the relationship between science and faith. Dawkins argues that atheism is a rational position and that religion can be harmful to society.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 2006, "The God Delusion", 20, null, null },
                    { 60, null, null, 7, 6, 4, null, null, "Steven Strogatz's 'Infinite Powers' tells the story of calculus and how it has shaped our understanding of the world. The book explores how calculus has been used to solve problems in physics, engineering, medicine, and other fields. Through engaging examples and historical anecdotes, Strogatz shows how calculus has revolutionized our ability to understand and manipulate the natural world.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 2019, "Infinite Powers", 10, null, null },
                    { 61, null, null, 7, 5, 4, null, null, "Steven Strogatz's 'Sync' explores the science of spontaneous order and how synchronization occurs in nature. The book examines how fireflies flash in unison, how the heart's cells beat together, and how other systems achieve coordination without central control. Strogatz explains the mathematical principles behind synchronization and its applications in various fields.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 2003, "Sync", 8, null, null },
                    { 62, null, null, 14, 9, 1, null, null, "Jane Austen's 'Emma' follows the titular character as she attempts to matchmake for her friends while learning about love and self-awareness. The novel explores themes of social class, marriage, and personal growth through Emma's journey from a well-meaning but misguided young woman to someone who understands herself and others better. Austen's wit and social commentary make this a classic of English literature.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 1815, "Emma", 14, null, null },
                    { 63, null, null, 14, 8, 1, null, null, "Jane Austen's 'Sense and Sensibility' follows the Dashwood sisters as they navigate love and marriage in early 19th-century England. The novel contrasts the practical Elinor with the romantic Marianne, exploring themes of love, family, and social expectations. Through the sisters' experiences, Austen examines the balance between reason and emotion in matters of the heart.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 1811, "Sense and Sensibility", 12, null, null },
                    { 64, null, null, 14, 6, 1, null, null, "Jane Austen's 'Mansfield Park' follows Fanny Price, a poor relation who is raised by her wealthy aunt and uncle. The novel explores themes of morality, social class, and the role of women in society through Fanny's experiences. Austen examines the contrast between true virtue and social pretension, creating a complex portrait of early 19th-century English society.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 1814, "Mansfield Park", 10, null, null },
                    { 65, null, null, 16, 10, 8, null, null, "Plato's 'The Republic' presents a dialogue on justice, the ideal state, and the nature of the soul. Through Socratic questioning, the book explores the meaning of virtue, the structure of society, and the pursuit of truth. The work examines the relationship between individual morality and political justice, proposing that a just society requires just individuals.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, -380, "The Republic", 15, null, null },
                    { 66, null, null, 16, 7, 8, null, null, "Plato's 'The Symposium' presents a series of speeches about love given at a drinking party in ancient Athens. The dialogue explores different conceptions of love, from physical attraction to spiritual connection, culminating in Socrates' account of the ladder of love. The work examines the nature of desire, beauty, and the human quest for transcendence.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, -385, "The Symposium", 11, null, null },
                    { 67, null, null, 16, 8, 8, null, null, "Plato's 'The Apology' records Socrates' defense speech at his trial for impiety and corrupting the youth of Athens. The dialogue presents Socrates' commitment to philosophical inquiry and his willingness to die for his principles. The work examines the conflict between individual conscience and state authority, and the role of the philosopher in society.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, -399, "The Apology", 12, null, null },
                    { 68, null, null, 18, 11, 9, null, null, "Charles Duhigg's 'The Power of Habit' uncovers the science behind why habits form and how they can be changed. Drawing on research and real-life stories, the book explains the habit loop and provides strategies for transforming routines. The work examines how habits shape individual behavior, organizational culture, and societal patterns.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 2012, "The Power of Habit", 18, null, null },
                    { 69, null, null, 18, 9, 9, null, null, "Charles Duhigg's 'Smarter Faster Better' explores the science of productivity and how successful people and organizations achieve their goals. The book examines eight key concepts that drive productivity, from motivation and focus to decision-making and innovation. Through case studies and research, Duhigg provides insights into how to work more effectively and achieve better results.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 2016, "Smarter Faster Better", 15, null, null },
                    { 70, null, null, 20, 7, 10, null, null, "Stephen R. Covey's 'The 8th Habit' builds on his previous work to address the challenges of the knowledge worker age. The book introduces the concept of finding your voice and helping others find theirs, emphasizing the importance of leadership and contribution. Covey examines how individuals can achieve personal and professional fulfillment in an increasingly complex world.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 2004, "The 8th Habit", 12, null, null },
                    { 71, null, null, 20, 8, 10, null, null, "Stephen R. Covey's 'First Things First' focuses on time management and prioritization based on principles rather than urgency. The book introduces the concept of the time management matrix and emphasizes the importance of aligning daily activities with long-term goals and values. Covey provides practical strategies for achieving balance and effectiveness in life.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 1994, "First Things First", 13, null, null },
                    { 72, null, null, 21, 12, 11, null, null, "E.H. Gombrich's 'The Story of Art' provides a comprehensive introduction to art history from prehistoric times to the modern era. The book presents art as a continuous narrative of human creativity and expression, making complex artistic movements accessible to general readers. Gombrich's engaging writing style and clear explanations have made this a classic introduction to art history.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 1950, "The Story of Art", 20, null, null },
                    { 73, null, null, 21, 6, 11, null, null, "E.H. Gombrich's 'Art and Illusion' examines the psychology of pictorial representation and how artists create the illusion of reality. The book explores the relationship between perception and artistic representation, drawing on psychology, philosophy, and art history. Gombrich examines how different cultures and periods have approached the challenge of representing the visual world.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 1960, "Art and Illusion", 10, null, null },
                    { 74, null, null, 22, 9, 11, null, null, "John Berger's 'Ways of Seeing' challenges conventional approaches to art appreciation and visual culture. Through a series of essays, Berger examines how we perceive and interpret images, questioning the assumptions behind traditional art criticism. The book explores themes of gender, class, and power in visual representation, offering new tools for analyzing visual culture.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 1972, "Ways of Seeing", 15, null, null },
                    { 75, null, null, 22, 5, 11, null, null, "John Berger's 'About Looking' is a collection of essays that examine how we see and interpret the world around us. The book explores various aspects of visual culture, from photography and painting to advertising and everyday objects. Berger's insightful analysis helps readers develop a more critical and aware approach to visual information.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 1980, "About Looking", 8, null, null },
                    { 76, null, null, 23, 8, 12, null, null, "Alex Ross's 'The Rest Is Noise' offers a sweeping history of 20th-century classical music, exploring how composers responded to the tumultuous events of their time. The book examines how music reflected and influenced social change, from the avant-garde experiments of Stravinsky to the minimalist movements of the late century. Ross's engaging narrative makes complex musical concepts accessible.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 2007, "The Rest Is Noise", 13, null, null },
                    { 77, null, null, 23, 6, 12, null, null, "Alex Ross's 'Listen to This' explores the connections between classical music and contemporary culture. The book examines how classical music continues to influence modern composers and performers, and how it intersects with popular music and other art forms. Ross provides insights into the enduring power and relevance of classical music in the 21st century.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 2010, "Listen to This", 10, null, null },
                    { 78, null, null, 24, 10, 12, null, null, "David Byrne's 'How Music Works' is a fascinating exploration of music from multiple perspectives: as a cultural phenomenon, a technological medium, and a fundamental human expression. The book covers topics ranging from the physics of sound to the economics of the music industry, from ancient musical traditions to digital innovations. Byrne's insights offer readers a deeper understanding of how music shapes our lives.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 2012, "How Music Works", 16, null, null },
                    { 79, null, null, 24, 5, 15, null, null, "David Byrne's 'Bicycle Diaries' chronicles his experiences cycling through various cities around the world. The book explores urban planning, culture, and the relationship between people and their environments. Through Byrne's observations and reflections, readers gain insights into how cities shape human experience and how cycling can provide a unique perspective on urban life.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 2009, "Bicycle Diaries", 8, null, null },
                    { 80, null, null, 25, 15, 9, null, null, "Bessel van der Kolk's 'The Body Keeps the Score' revolutionizes our understanding of trauma and its profound effects on the brain, mind, and body. The book explores innovative treatment approaches, from traditional therapy to body-based interventions like yoga and neurofeedback. Van der Kolk's compassionate perspective offers hope for healing while providing essential insights for anyone affected by trauma.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 2014, "The Body Keeps the Score", 25, null, null },
                    { 81, null, null, 25, 8, 9, null, null, "Bessel van der Kolk's 'Traumatic Stress' provides a comprehensive overview of the field of trauma studies and treatment. The book examines the neurobiological effects of trauma, the development of PTSD, and various therapeutic approaches. Van der Kolk's extensive clinical experience and research provide a solid foundation for understanding and treating trauma-related disorders.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 1996, "Traumatic Stress", 12, null, null },
                    { 82, null, null, 26, 12, 13, null, null, "Christopher McDougall's 'Born to Run' combines adventure, science, and human potential in a compelling narrative about the art and science of running. The book follows McDougall's journey to discover the secrets of the Tarahumara, a remote Mexican tribe known for their extraordinary long-distance running abilities. Through their story, McDougall explores evolutionary biology, biomechanics, and the psychology of endurance.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 2009, "Born to Run", 20, null, null },
                    { 83, null, null, 26, 7, 13, null, null, "Christopher McDougall's 'Natural Born Heroes' explores the science of heroism and how ordinary people can achieve extraordinary feats. The book examines the physical and mental techniques used by heroes throughout history, from ancient Greek warriors to modern athletes. McDougall investigates how nutrition, movement, and mindset can unlock human potential.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 2015, "Natural Born Heroes", 12, null, null },
                    { 84, null, null, 27, 15, 14, null, null, "Irma S. Rombauer's 'The Joy of Cooking' has become an American culinary institution, serving as the definitive cookbook for generations of home cooks. First published during the Great Depression, the book has evolved through multiple editions while maintaining its practical approach to cooking. Rombauer's warm, encouraging voice and comprehensive coverage of techniques make complex recipes accessible to beginners.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 1931, "The Joy of Cooking", 25, null, null },
                    { 85, null, null, 28, 10, 14, null, null, "Samin Nosrat's 'Salt, Fat, Acid, Heat' revolutionizes how we think about cooking by focusing on the four fundamental elements that make food delicious. Rather than memorizing recipes, Nosrat teaches readers to understand the principles behind great cooking, empowering them to create flavorful dishes with confidence. The book combines scientific explanations with practical techniques and beautiful illustrations.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 2017, "Salt, Fat, Acid, Heat", 18, null, null },
                    { 86, null, null, 29, 12, 14, null, null, "Anthony Bourdain's 'Kitchen Confidential' pulls back the curtain on the culinary world, revealing the intense, chaotic, and often brutal reality behind restaurant kitchens. Bourdain's candid and sometimes controversial memoir exposes the passion, pressure, and personalities that drive the food industry. Through vivid storytelling and sharp wit, he shares the lessons learned from his years in professional kitchens.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 2000, "Kitchen Confidential", 20, null, null },
                    { 87, null, null, 29, 8, 14, null, null, "Anthony Bourdain's 'Medium Raw' is a follow-up to 'Kitchen Confidential' that explores how the food world has changed and how Bourdain's own perspective has evolved. The book examines celebrity chefs, food television, and the changing landscape of the restaurant industry. Bourdain's sharp observations and honest reflections provide insights into the evolution of food culture.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 2010, "Medium Raw", 13, null, null },
                    { 88, null, null, 30, 14, 14, null, null, "Michael Pollan's 'The Omnivore's Dilemma' investigates the complex web of choices involved in what we eat, tracing the journey of food from farm to table. Through four different meals, Pollan explores industrial agriculture, organic farming, hunting and gathering, and sustainable food systems. The book examines the environmental, ethical, and health implications of our food choices.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 2006, "The Omnivore's Dilemma", 22, null, null },
                    { 89, null, null, 30, 11, 14, null, null, "Michael Pollan's 'In Defense of Food' examines the modern food industry and its impact on human health. The book explores how processed foods and industrial agriculture have changed our diets and health outcomes. Pollan provides practical advice for making healthier food choices and argues for a return to traditional, whole-food diets.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 2008, "In Defense of Food", 18, null, null },
                    { 90, null, null, 30, 7, 2, null, null, "Michael Pollan's 'The Botany of Desire' explores the complex relationship between humans and plants, examining how plants have evolved to satisfy human desires for sweetness, beauty, intoxication, and control. The book tells the stories of four plants—apples, tulips, marijuana, and potatoes—and how they have shaped human history and culture.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 2001, "The Botany of Desire", 12, null, null },
                    { 91, null, null, 31, 9, 21, null, null, "Stephen King's debut novel 'Carrie' tells the story of a teenage girl with telekinetic powers who is bullied by her classmates and abused by her religious fanatic mother. The novel explores themes of isolation, revenge, and the destructive power of religious extremism. King's portrayal of high school cruelty and supernatural horror established him as a master of the genre.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 1974, "Carrie", 15, null, null },
                    { 92, null, null, 31, 11, 21, null, null, "Stephen King's 'The Shining' follows the Torrance family as they spend the winter as caretakers of the isolated Overlook Hotel. The novel explores themes of isolation, alcoholism, and the supernatural as the hotel's malevolent forces begin to affect the family. King's masterful building of tension and psychological horror makes this one of his most acclaimed works.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 1977, "The Shining", 18, null, null },
                    { 93, null, null, 31, 13, 21, null, null, "Stephen King's 'It' follows a group of children who band together to fight an ancient evil that takes the form of a clown and feeds on their fears. The novel alternates between their childhood experiences and their return as adults to face the evil again. King explores themes of friendship, courage, and the power of belief in this epic horror novel.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 1986, "It", 20, null, null },
                    { 94, null, null, 31, 10, 18, null, null, "Stephen King's 'The Stand' is an epic post-apocalyptic novel about a deadly virus that wipes out most of humanity, leaving survivors to choose between good and evil. The novel explores themes of morality, community, and the struggle between light and darkness. King's detailed character development and complex plot make this one of his most ambitious works.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 1978, "The Stand", 16, null, null },
                    { 95, null, null, 32, 15, 16, null, null, "Maurice Sendak's 'Where the Wild Things Are' follows young Max as he sails to an island inhabited by wild creatures who make him their king. The picture book explores themes of imagination, anger, and the comfort of home. Sendak's innovative illustrations and simple but profound story have made this a beloved classic of children's literature.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 1963, "Where the Wild Things Are", 25, null, null },
                    { 96, null, null, 33, 18, 17, null, null, "J.R.R. Tolkien's 'The Hobbit' follows Bilbo Baggins, a hobbit who joins a group of dwarves on a quest to reclaim their homeland from a dragon. The novel explores themes of courage, friendship, and the journey of self-discovery. Tolkien's rich world-building and engaging storytelling established the foundation for his later masterpiece, 'The Lord of the Rings.'", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 1937, "The Hobbit", 30, null, null },
                    { 97, null, null, 33, 20, 17, null, null, "J.R.R. Tolkien's 'The Lord of the Rings' is an epic fantasy trilogy that follows the quest to destroy a powerful ring and defeat the dark lord Sauron. The novel explores themes of friendship, sacrifice, and the struggle between good and evil. Tolkien's detailed world-building, complex characters, and profound themes have made this one of the most influential works of fantasy literature.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 1954, "The Lord of the Rings", 35, null, null },
                    { 98, null, null, 33, 8, 17, null, null, "J.R.R. Tolkien's 'The Silmarillion' is a collection of mythopoeic stories that form the background to 'The Lord of the Rings.' The book includes the creation myth of Middle-earth, the history of the elves, and the tales of the Silmarils. Tolkien's complex mythology and beautiful prose create a rich foundation for understanding the world of Middle-earth.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 1977, "The Silmarillion", 15, null, null },
                    { 99, null, null, 35, 16, 18, null, null, "Frank Herbert's 'Dune' is set on the desert planet Arrakis and follows Paul Atreides as he becomes involved in a complex political and religious struggle. The novel explores themes of ecology, politics, religion, and human evolution. Herbert's detailed world-building and complex plot have made this one of the most influential works of science fiction.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 1965, "Dune", 25, null, null },
                    { 100, null, null, 35, 12, 18, null, null, "Frank Herbert's 'Dune Messiah' continues the story of Paul Atreides as he struggles with the consequences of his rise to power and the religious movement that has grown around him. The novel explores themes of leadership, prophecy, and the unintended consequences of political and religious power. Herbert examines the complexities of messianic figures and their impact on society.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 1969, "Dune Messiah", 20, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Set in the Roaring Twenties, 'The Great Gatsby' follows the enigmatic millionaire Jay Gatsby as he pursues his love for Daisy Buchanan. Through the eyes of Nick Carraway, the novel explores themes of wealth, illusion, and the American dream, painting a vivid portrait of a society obsessed with status, longing, and the pursuit of happiness.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Set in the racially charged Deep South of the 1930s, this classic novel follows Scout Finch and her brother Jem as their father, Atticus, defends a black man falsely accused of a crime. Through the children's eyes, the story explores themes of justice, morality, and the loss of innocence in a divided society.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Yuval Noah Harari's 'Sapiens' takes readers on a sweeping journey through the history of humanity, from the emergence of Homo sapiens in Africa to the present day. The book examines how biology, culture, and economics have shaped our species, offering thought-provoking insights into what it means to be human.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "'Educated' is the remarkable memoir of Tara Westover, who grew up in a strict and isolated survivalist family in rural Idaho. Denied formal education, she eventually escapes her upbringing and pursues learning, ultimately earning a PhD from Cambridge. Her story is one of resilience, transformation, and the power of education to change lives.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "Stephen Hawking's groundbreaking work explores the origins, structure, and fate of the universe. Written for a general audience, the book delves into concepts like black holes, the Big Bang, and the nature of time itself, making complex scientific ideas accessible and inspiring curiosity about the cosmos.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 21,
                column: "Description",
                value: "An accessible introduction to the history of art by renowned art historian E.H. Gombrich.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 22,
                column: "Description",
                value: "A groundbreaking book on visual culture and how we perceive art, written by John Berger.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 23,
                column: "Description",
                value: "A history of 20th-century classical music by music critic Alex Ross.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 24,
                column: "Description",
                value: "David Byrne's exploration of music, its history, and its cultural impact.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 25,
                column: "Description",
                value: "Bessel van der Kolk's exploration of trauma and its effect on the brain and body.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 26,
                column: "Description",
                value: "A book about the science of running and the story of a remote tribe of ultra-runners.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 27,
                column: "Description",
                value: "Irma S. Rombauer's classic cookbook that has become an American institution.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 28,
                column: "Description",
                value: "A guide to understanding the fundamental elements of cooking by Samin Nosrat.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 29,
                column: "Description",
                value: "Anthony Bourdain's behind-the-scenes look at the culinary world.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 30,
                column: "Description",
                value: "Michael Pollan's exploration of where our food comes from and its environmental impact.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 31,
                column: "Description",
                value: "Stephen King's memoir and guide to writing.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 32,
                column: "Description",
                value: "Anne Lamott's insightful and humorous take on writing and life.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 33,
                column: "Description",
                value: "A concise guide to the principles of good writing, by William Strunk Jr. and E.B. White.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 34,
                column: "Description",
                value: "Steven Pressfield's book on overcoming resistance to creative work.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 35,
                column: "Description",
                value: "Paulo Coelho's philosophical novel about pursuing your dreams and finding your destiny.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 36,
                column: "Description",
                value: "George Orwell's dystopian novel about totalitarianism, surveillance, and the power of propaganda.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 37,
                column: "Description",
                value: "Aldous Huxley's novel exploring a future society controlled by technology and conformity.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 38,
                column: "Description",
                value: "Ray Bradbury's classic novel about a dystopian society where books are banned.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 39,
                column: "Description",
                value: "J.D. Salinger's novel about teenage rebellion and disillusionment.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 40,
                column: "Description",
                value: "Margaret Atwood's dystopian novel about gender oppression and the loss of personal freedom.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 41,
                column: "Description",
                value: "Cormac McCarthy's post-apocalyptic novel about a father and son struggling to survive.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 42,
                column: "Description",
                value: "Kate Atkinson's novel about a woman who lives multiple lives in different timelines.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 43,
                column: "Description",
                value: "Rick Yancey's thrilling novel about an alien invasion and the fight for survival.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 44,
                column: "Description",
                value: "Suzanne Collins' dystopian novel about a televised fight to the death.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 45,
                column: "Description",
                value: "Veronica Roth's novel set in a dystopian society divided into factions based on virtues.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 46,
                column: "Description",
                value: "Paula Hawkins' psychological thriller about a woman who gets involved in a missing person's case.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 47,
                column: "Description",
                value: "Gillian Flynn's mystery novel about a marriage gone wrong and the disappearance of a wife.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 48,
                column: "Description",
                value: "Gillian Flynn's psychological thriller about a journalist returning to her hometown to investigate a series of murders.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 49,
                column: "Description",
                value: "Liane Moriarty's novel about the secrets and lies in a tight-knit community.");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 50,
                column: "Description",
                value: "Stieg Larsson's crime thriller about a journalist and a hacker uncovering corruption in Sweden.");
        }
    }
}
