# DataGenerator

Automatically generate intelligent and realistic test data for an object.

[![Build status](https://ci.appveyor.com/api/projects/status/v9h2sdvcgmo4itj1?svg=true)](https://ci.appveyor.com/project/LoreSoft/DataGenerator)

## Download

The DataGenerator library is available on nuget.org via package name `DataGenerator`.

To install DataGenerator, run the following command in the Package Manager Console

    PM> Install-Package DataGenerator
    
More information about NuGet package available at
<https://nuget.org/packages/DataGenerator>

## Development Builds


Development builds are available on the myget.org feed.  A development build is promoted to the main NuGet feed when it's determined to be stable. 

In your Package Manager settings add the following package source for development builds:
<http://www.myget.org/F/loresoft/>

## Features

- Generate intelligent test data based on property type and name
- Automatic discovery of data sources
- Fully customizable property data sources
- Realistic data sources 
- Weighted value selection
- Easy fluent API


## Configuration

Full class configuration

```csharp
Generator.Configure(c => c
    .Entity<User>(e =>
    {
        e.Property(p => p.FirstName).DataSource<FirstNameSource>();
        e.Property(p => p.LastName).DataSource<LastNameSource>();
        e.Property(p => p.Address1).DataSource<StreetSource>();
        e.Property(p => p.City).DataSource<CitySource>();
        e.Property(p => p.State).DataSource<StateSource>();
        e.Property(p => p.Zip).DataSource<PostalCodeSource>();

        e.Property(p => p.Note).DataSource<LoremIpsumSource>();
        e.Property(p => p.Password).DataSource<PasswordSource>();

        // array of values
        e.Property(p => p.Status).DataSource(new[] { Status.New, Status.Verified });


        // don't generate
        e.Property(p => p.Budget).Ignore();

        // static value
        e.Property(p => p.IsActive).Value(true);

        // delegate value
        e.Property(p => p.Created).Value(() => DateTime.Now);
    })
);
```

Example of configuration for generating child classes

```csharp
Generator.Configure(c => c
    .Entity<Order>(e =>
    {
        e.AutoMap();
        e.Property(p => p.User).Value(Generator.Single<User>);
        e.Property(p => p.Items).Value(() => Generator.List<OrderLine>(2).ToList());
    })
    .Entity<OrderLine>(e =>
    {
        e.AutoMap();
        e.Property(p => p.Quantity).IntegerSource(1, 10);
    })
);
```

## Generation

Generate test data 

```csharp
// generate a user
var instance = Generator.Single<User>();

// generate 10 users
var users = Generator.List<User>(10)
            
```

## Data Sources

### Primitive Value Data Sources

**BooleanSource** - Generates a random true or false    
**DateTimeSource** - Generates a random date plus or minus 10 years from now    
**DecimalSource** - Generates a random decimal between 0 and 1,000,000    
**FloatSource** - Generates a random float between 0 and 1,000,000    
**GuidSource** - Generates a random GUID value    
**IntegerSource** - Generates a random integer between 0 and 32,000    
**ListDataSource** - Random value from the specified list     
**TimeSpanSource** - Generates a random date plus or minus 10 years from now    
**ValueSource** - Static value source    

### Smart Data Sources

**CitySource** - Random city name from a list of the largest US cities    
**CompanySource** - Random company name from a list of fortune 500 companies   
**EmailSource** - Random email address using common domains
**EnumSource** - Random value from available enum values   
**FirstNameSource** - Random first name from 100 common first names    
**IdentifierSource** - Random identifier value    
**LastNameSource** - Random last name from 100 common last names    
**LoremIpsumSource** - Random lorem ipsum text    
**MoneySource** - Random dollar amount between 0 and 10,000    
**NameSource** - Random code name from various sources    
**PasswordSource** - Random pronounceable password    
**PhoneSource** - Random phone number in US format    
**PostalCodeSource** - Random US zip code    
**StateSource** - Random US State    
**StreetSource** - Random US house number and street    
**WebsiteSource** - Random website from top 100 list    
