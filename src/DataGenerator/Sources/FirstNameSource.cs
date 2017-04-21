using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator.Sources
{
    /// <summary>
    /// First name data source generator
    /// </summary>
    /// <seealso cref="DataGenerator.Sources.DataSourceMatchName" />
    public class FirstNameSource : DataSourceMatchName
    {
        private static readonly string[] _names = { "FirstName", "GivenName" };
        private static readonly Type[] _types = { typeof(string) };
        private static readonly string[] _firstNames =
        {
            "James", "John", "Robert", "Mary", "Michael", "William", "David", "Richard", "Charles", "Joseph", "Thomas", "Patricia", "Linda", "Christopher", "Barbara", "Elizabeth", "Daniel", "Jennifer", "Paul", "Mark",
            "Donald", "George", "Maria", "Susan", "Kenneth", "Margaret", "Steven", "Edward", "Dorothy", "Brian", "Lisa", "Ronald", "Anthony", "Nancy", "Karen", "Betty", "Helen", "Kevin", "Jason", "Matthew", "Sandra",
            "Gary", "Timothy", "Jose", "Donna", "Larry", "Jeffrey", "Carol", "Ruth", "Frank", "Scott", "Eric", "Sharon", "Michelle", "Stephen", "Andrew", "Laura", "Sarah", "Kimberly", "Deborah", "Jessica", "Shirley",
            "Cynthia", "Raymond", "Angela", "Melissa", "Brenda", "Amy", "Anna", "Rebecca", "Virginia", "Kathleen", "Gregory", "Joshua", "Pamela", "Jerry", "Martha", "Debra", "Amanda", "Stephanie", "Dennis", "Carolyn",
            "Walter", "Christine", "Marie", "Janet", "Patrick", "Catherine", "Frances", "Peter", "Ann", "Joyce", "Diane", "Alice", "Harold", "Douglas", "Henry", "Julie", "Heather", "Teresa", "Doris", "Gloria", "Carl",
            "Evelyn", "Arthur", "Ryan", "Jean", "Cheryl", "Mildred", "Katherine", "Roger", "Joe", "Joan", "Juan", "Ashley", "Jack", "Albert", "Jonathan", "Justin", "Terry", "Judith", "Gerald", "Keith", "Rose", "Samuel",
            "Willie", "Janice", "Kelly", "Nicole", "Judy", "Christina", "Kathy", "Ralph", "Lawrence", "Theresa", "Beverly", "Nicholas", "Denise", "Roy", "Benjamin", "Tammy", "Bruce", "Irene", "Jane", "Brandon", "Adam",
            "Lori", "Rachel", "Harry", "Fred", "Marilyn", "Wayne", "Billy", "Steve", "Andrea", "Kathryn", "Louis", "Jeremy", "Aaron", "Louise", "Sara", "Anne", "Jacqueline", "Wanda", "Bonnie", "Julia", "Randy", "Howard",
            "Eugene", "Ruby", "Carlos", "Lois", "Tina", "Phyllis", "Norma", "Paula", "Diana", "Annie", "Russell", "Bobby", "Victor", "Lillian", "Emily", "Robin", "Peggy", "Martin", "Crystal", "Ernest", "Gladys", "Phillip",
            "Todd", "Rita", "Dawn", "Jesse", "Connie", "Florence", "Craig", "Tracy", "Edna", "Alan", "Tiffany", "Carmen", "Rosa", "Shawn", "Cindy", "Clarence", "Sean", "Philip", "Chris", "Grace", "Johnny", "Earl",
            "Wendy", "Jimmy", "Antonio", "Danny", "Bryan", "Tony", "Luis", "Mike", "Victoria", "Edith", "Stanley", "Leonard", "Kim", "Sherry", "Nathan", "Sylvia", "Josephine", "Dale", "Thelma", "Shannon", "Sheila",
            "Ethel", "Manuel", "Ellen", "Elaine", "Marjorie", "Rodney", "Curtis", "Carrie", "Norman", "Charlotte", "Allen", "Monica", "Esther", "Pauline", "Emma", "Marvin", "Juanita", "Anita", "Rhonda", "Vincent",
            "Hazel", "Glenn", "Amber", "Jeffery", "Travis", "Jeff", "Eva", "Chad", "Jacob", "Debbie", "Lee", "Melvin", "Alfred", "April", "Leslie", "Kyle", "Francis", "Clara", "Lucille", "Jamie", "Bradley", "Joanne",
            "Eleanor", "Valerie", "Danielle", "Jesus", "Herbert", "Frederick", "Ray", "Megan", "Joel", "Alicia", "Suzanne", "Michele", "Gail", "Bertha", "Edwin", "Darlene", "Veronica", "Jill", "Erin", "Geraldine",
            "Don", "Eddie", "Lauren", "Cathy", "Joann", "Ricky", "Lorraine", "Lynn", "Sally", "Regina", "Troy", "Randall", "Erica", "Beatrice", "Dolores", "Barry", "Bernice", "Audrey", "Alexander", "Yvonne", "Annette",
            "June", "Samantha", "Bernard", "Marion", "Dana", "Stacy", "Mario", "Leroy", "Ana", "Renee", "Francisco", "Marcus", "Micheal", "Theodore", "Clifford", "Ida", "Vivian", "Miguel", "Oscar", "Roberta", "Holly",
            "Brittany", "Melanie", "Loretta", "Yolanda", "Jeanette", "Laurie", "Jay", "Jim", "Katie", "Tom", "Kristen", "Vanessa", "Alma", "Sue", "Calvin", "Alex", "Jon", "Elsie", "Beth", "Jeanne", "Vicki", "Ronnie",
            "Bill", "Lloyd", "Tommy", "Leon", "Derek", "Carla", "Tara", "Rosemary", "Warren", "Eileen", "Terri", "Darrell", "Jerome", "Gertrude", "Lucy", "Floyd", "Tonya", "Leo", "Ella", "Stacey", "Alvin", "Tim",
            "Wesley", "Gordon", "Dean", "Greg", "Jorge", "Wilma", "Gina", "Kristin", "Dustin", "Pedro", "Derrick", "Jessie", "Natalie", "Agnes", "Vera", "Dan", "Willie", "Charlene", "Bessie", "Lewis", "Zachary", "Delores",
            "Corey", "Melinda", "Pearl", "Arlene", "Herman", "Maurice", "Vernon", "Roberto", "Maureen", "Colleen", "Allison", "Tamara", "Clyde", "Joy", "Georgia", "Constance", "Glen", "Hector", "Lillie", "Claudia",
            "Jackie", "Marcia", "Shane", "Ricardo", "Tanya", "Nellie", "Minnie", "Sam", "Marlene", "Heidi", "Glenda", "Rick", "Lester", "Brent", "Ramon", "Charlie", "Lydia", "Viola", "Courtney", "Marian", "Tyler",
            "Gilbert", "Stella", "Caroline", "Dora", "Gene", "Marc", "Jo", "Vickie", "Mattie", "Reginald", "Terry", "Maxine", "Irma", "Ruben", "Brett", "Angel", "Mabel", "Marsha", "Myrtle", "Nathaniel", "Rafael",
            "Leslie", "Lena", "Christy", "Edgar", "Milton", "Deanna", "Patsy", "Raul", "Hilda", "Ben", "Chester", "Cecil", "Duane", "Franklin", "Gwendolyn", "Andre", "Jennie", "Nora", "Margie", "Nina", "Cassandra",
            "Leah", "Elmer", "Penny", "Kay", "Priscilla", "Naomi", "Carole", "Brad", "Gabriel", "Brandy", "Olga", "Ron", "Mitchell", "Roland", "Arnold", "Harvey", "Billie", "Dianne", "Tracey", "Leona", "Jared", "Jenny",
            "Felicia", "Sonia", "Adrian", "Karl", "Miriam", "Velma", "Becky", "Cory", "Claude", "Erik", "Bobbie", "Violet", "Kristina", "Darryl", "Toni", "Jamie", "Neil", "Misty", "Mae", "Jessie", "Christian", "Javier",
            "Fernando", "Clinton", "Shelly", "Daisy", "Ramona", "Sherri", "Ted", "Mathew", "Tyrone", "Darren", "Lonnie", "Erika", "Katrina", "Claire", "Lance", "Cody", "Julio", "Kelly", "Lindsey", "Lindsay", "Kurt",
            "Geneva", "Guadalupe", "Belinda", "Margarita", "Sheryl", "Allan", "Nelson", "Cora", "Faye", "Guy", "Clayton", "Hugh", "Ada", "Natasha", "Sabrina", "Isabel", "Max", "Dwayne", "Marguerite", "Hattie", "Harriet",
            "Dwight", "Armando", "Felix", "Jimmie", "Molly", "Cecilia", "Kristi", "Brandi", "Blanche", "Sandy", "Rosie", "Joanna", "Iris", "Everett", "Eunice", "Angie", "Jordan", "Ian", "Wallace", "Inez", "Lynda",
            "Ken", "Bob", "Jaime", "Madeline", "Amelia", "Alberta", "Casey", "Alfredo", "Genevieve", "Monique", "Jodi", "Janie", "Maggie", "Kayla", "Sonya", "Jan", "Lee", "Kristine", "Candace", "Alberto", "Dave",
            "Ivan", "Fannie", "Maryann", "Opal", "Alison", "Yvette", "Melody", "Johnnie", "Sidney", "Byron", "Julian", "Isaac", "Morris", "Luz", "Susie", "Olivia", "Flora", "Shelley", "Clifton", "Willard", "Daryl",
            "Ross", "Kristy", "Mamie", "Lula", "Lola", "Verna", "Beulah", "Antoinette", "Virgil", "Andy", "Marshall", "Salvador", "Perry", "Kirk", "Sergio", "Marion", "Tracy", "Seth", "Kent", "Terrance", "Rene", "Candice",
            "Juana", "Jeannette", "Pam", "Kelli", "Eduardo", "Terrence", "Hannah", "Whitney", "Bridget", "Enrique", "Freddie", "Karla", "Celia", "Wade", "Latoya", "Patty", "Shelia", "Gayle", "Della", "Vicky", "Lynne",
            "Austin", "Stuart", "Sheri", "Marianne", "Fredrick", "Arturo", "Alejandro", "Jackie", "Joey", "Nick", "Luther", "Kara", "Jacquelyn", "Erma", "Blanca", "Wendell", "Jeremiah", "Evan", "Julius", "Dana", "Myra",
            "Leticia", "Pat", "Krista", "Roxanne", "Donnie", "Otis", "Angelica", "Johnnie", "Robyn", "Francis", "Adrienne", "Rosalie", "Alexandra", "Brooke", "Bethany", "Sadie", "Bernadette", "Shannon", "Trevor",
            "Oliver", "Luke", "Homer", "Gerard", "Doug", "Traci", "Jody", "Kendra", "Jasmine", "Nichole", "Rachael", "Chelsea", "Mable", "Ernestine", "Muriel", "Kenny", "Hubert", "Angelo", "Shaun", "Marcella", "Elena",
            "Krystal", "Angelina", "Lyle", "Matt", "Lynn", "Alfonso", "Nadine", "Kari", "Estelle", "Dianna", "Paulette", "Lora", "Orlando", "Rex", "Carlton", "Ernesto", "Cameron", "Neal", "Mona", "Doreen", "Rosemarie",
            "Angel", "Desiree", "Antonia", "Pablo", "Lorenzo", "Omar", "Wilbur", "Blake", "Grant", "Horace", "Roderick", "Kerry", "Hope", "Ginger", "Janis", "Betsy", "Christie", "Freda", "Abraham", "Willis", "Rickey",
            "Jean", "Ira", "Mercedes", "Meredith", "Lynette", "Teri", "Cristina", "Eula", "Andres", "Cesar", "Johnathan", "Malcolm", "Rudolph", "Damon", "Kelvin", "Rudy", "Preston", "Leigh", "Meghan", "Sophia", "Eloise",
            "Rochelle", "Gretchen", "Cecelia", "Alton", "Archie", "Marco", "Wm", "Raquel", "Henrietta", "Alyssa", "Jana", "Kelley", "Gwen", "Kerry", "Pete", "Randolph", "Garry", "Geoffrey", "Jonathon", "Felipe", "Bennie",
            "Gerardo", "Ed", "Dominic", "Robin", "Loren", "Jenna", "Tricia", "Laverne", "Olive", "Alexis", "Tasha", "Delbert", "Colin", "Guillermo", "Earnest", "Lucas", "Silvia", "Elvira", "Casey", "Delia", "Sophie",
            "Kate", "Patti", "Lorena", "Kellie", "Sonja", "Lila", "Lana", "Darla", "May", "Mindy", "Essie", "Mandy", "Benny", "Noel", "Spencer", "Rodolfo", "Myron", "Edmund", "Lorene", "Elsa", "Josefina", "Jeannie",
            "Miranda", "Dixie", "Lucia", "Marta", "Faith", "Lela", "Johanna", "Shari", "Camille", "Garrett", "Salvatore", "Cedric", "Lowell", "Gregg", "Tami", "Shawna", "Elisa", "Ebony", "Melba", "Ora", "Nettie",
            "Tabitha", "Ollie", "Jaime", "Winifred", "Kristie", "Marina", "Alisha", "Aimee", "Rena", "Sherman", "Wilson", "Devin", "Sylvester", "Kim", "Roosevelt", "Israel", "Jermaine", "Myrna", "Marla", "Tammie",
            "Latasha", "Bonita", "Patrice", "Ronda", "Sherrie", "Addie", "Forrest", "Wilbert", "Leland", "Francine", "Deloris", "Stacie", "Adriana", "Cheri", "Shelby", "Abigail", "Celeste", "Jewel", "Cara", "Adele",
            "Rebekah", "Lucinda", "Dorthy", "Simon", "Guadalupe", "Clark", "Irving", "Carroll", "Bryant", "Owen", "Rufus", "Woodrow", "Sammy", "Kristopher", "Mack", "Levi", "Marcos", "Gustavo", "Jake", "Chris", "Effie",
            "Trina", "Reba", "Shawn", "Sallie", "Aurora", "Lenora", "Etta", "Lottie", "Kerri", "Trisha", "Nikki", "Estella", "Francisca", "Josie", "Tracie", "Marissa", "Karin", "Brittney", "Janelle", "Lourdes", "Laurel",
            "Helene", "Fern", "Elva", "Corinne", "Kelsey", "Lionel", "Marty", "Taylor", "Ellis", "Dallas", "Gilberto", "Clint", "Nicolas", "Laurence", "Ismael", "Orville", "Drew", "Jody", "Ina", "Bettie", "Elisabeth",
            "Aida", "Caitlin", "Ingrid", "Iva", "Eugenia", "Christa", "Goldie", "Cassie", "Maude", "Jenifer", "Ervin", "Dewey", "Al", "Wilfred", "Josh", "Hugo", "Ignacio", "Caleb", "Tomas", "Sheldon", "Erick", "Frankie",
            "Therese", "Frankie", "Dena", "Lorna", "Janette", "Latonya", "Candy", "Morgan", "Consuelo", "Tamika", "Rosetta", "Debora", "Cherie", "Polly", "Dina", "Stewart", "Doyle", "Darrel", "Rogelio", "Terence",
            "Santiago", "Alonzo", "Elias", "Bert", "Elbert", "Ramiro", "Conrad", "Pat", "Noah", "Jewell", "Fay", "Jillian", "Dorothea", "Nell", "Trudy", "Esperanza", "Patrica", "Kimberley", "Shanna", "Helena", "Carolina",
            "Cleo", "Stefanie", "Grady", "Phil", "Cornelius", "Lamar", "Rolando", "Clay", "Percy", "Dexter", "Bradford", "Merle", "Rosario", "Ola", "Janine", "Darin", "Amos", "Terrell", "Moses", "Irvin", "Saul", "Roman",
            "Darnell", "Randal", "Tommie", "Timmy", "Darrin", "Winston", "Brendan", "Toby", "Van", "Abel", "Dominick", "Boyd", "Courtney", "Jan", "Emilio", "Elijah", "Cary", "Domingo", "Santos", "Aubrey", "Emmett",
            "Marlon", "Emanuel", "Jerald", "Edmond", "Emil", "Dewayne", "Will", "Otto", "Teddy", "Reynaldo", "Bret", "Morgan", "Jess", "Trent", "Humberto", "Emmanuel", "Stephan", "Louie", "Vicente", "Lamont", "Stacy",
            "Garland", "Miles", "Micah", "Efrain", "Billie", "Logan", "Heath", "Rodger", "Harley", "Demetrius", "Ethan", "Eldon", "Rocky", "Pierre", "Junior", "Freddy", "Eli", "Bryce", "Antoine", "Robbie", "Kendall",
            "Royce", "Sterling", "Mickey", "Chase", "Grover", "Elton", "Cleveland", "Dylan", "Chuck", "Damian", "Reuben", "Stan", "August", "Leonardo", "Jasper", "Russel", "Erwin", "Benito", "Hans", "Monte", "Blaine",
            "Ernie", "Curt", "Quentin", "Agustin", "Murray", "Jamal", "Devon", "Adolfo", "Harrison", "Tyson", "Burton", "Brady", "Elliott", "Wilfredo", "Bart", "Jarrod", "Vance", "Denis", "Damien", "Joaquin", "Harlan",
            "Desmond", "Elliot", "Darwin", "Ashley", "Gregorio", "Buddy", "Xavier", "Kermit", "Roscoe", "Esteban", "Anton", "Solomon", "Scotty", "Norbert", "Elvin", "Williams", "Nolan", "Carey", "Rod", "Quinton"
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="FirstNameSource"/> class.
        /// </summary>
        public FirstNameSource() : base(_types, _names)
        {
        }

        /// <summary>
        /// Get a value from the data source.
        /// </summary>
        /// <param name="generateContext">The generate context.</param>
        /// <returns>
        /// A new value from the data source.
        /// </returns>
        public override object NextValue(IGenerateContext generateContext)
        {
            return _firstNames[RandomGenerator.Current.Next(0, _firstNames.Length)];
        }
    }
}
