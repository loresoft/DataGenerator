# DataGenerator

Automatically generate intelligent and realistic test data for an object.

[![Build status](https://ci.appveyor.com/api/projects/status/toygpxy8o3u2b9ah?svg=true)](https://ci.appveyor.com/project/LoreSoft/DataGenerator)

[![NuGet Version](https://img.shields.io/nuget/v/DataGenerator.svg?style=flat-square)](https://www.nuget.org/packages/DataGenerator/)

[![NuGet Version](https://img.shields.io/nuget/dt/DataGenerator.svg?style=flat-square)](https://www.nuget.org/packages/DataGenerator/)

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

Full class property configuration

```csharp
Generator.Default.Configure(c => c
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
Generator.Default.Configure(c => c
    .Entity<Order>(e =>
    {
        e.AutoMap();
        // generate a User instance
        e.Property(p => p.User).Single<User>();
        // generate list of OrderLine items
        e.Property(p => p.Items).List<OrderLine>(2);
    })
    .Entity<OrderLine>(e =>
    {
        e.AutoMap();
        e.Property(p => p.Quantity).IntegerSource(1, 10);
    })
);
```
There are extension methods to configure properties as well

```csharp
Generator.Default.Configure(c => c
    .Entity<OrderLine>(e =>
    {
        // random number between 1 and 10
        e.Property(p => p.Quantity).IntegerSource(1, 10);
        // between 100 and 1,000
        e.Property(p => p.UnitAmount).DecimalSource(100, 1000);
    })
);
```

### Profiles

DataGenerator support class profiles to make configuration easier.  To create a profile, inherit from the `MappingProfile<T>` base class.

Sample Profile for the User class

```csharp
public class UserProfile : MappingProfile<User>
{
    public override void Configure()
    {
        Property(p => p.FirstName).DataSource<FirstNameSource>();
        Property(p => p.LastName).DataSource<LastNameSource>();
        Property(p => p.Address1).DataSource<StreetSource>();
        Property(p => p.City).DataSource<CitySource>();
        Property(p => p.State).DataSource<StateSource>();
        Property(p => p.Zip).DataSource<PostalCodeSource>();
        
        Property(p => p.Note).DataSource<LoremIpsumSource>();
        Property(p => p.Password).DataSource<PasswordSource>();
        
        // array of values
        Property(p => p.Status).DataSource(new[] { Status.New, Status.Verified });
        
        
        // don't generate
        Property(p => p.Budget).Ignore();
        
        // static value
        Property(p => p.IsActive).Value(true);
        
        // delegate value
        Property(p => p.Created).Value(() => DateTime.UtcNow);
    }
}

```

Register a profile in the configuration

```csharp
Generator.Default.Configure(c => c
  .Profile<UserProfile>()
);
```

## Generation

Generate test data

```csharp
// generate a user
var instance = Generator.Default.Single<User>();

// generate 10 users
var users = Generator.Default.List<User>(10)

```

You can override the configuration

```csharp
var instance = Generator.Default.Single<User>(c =>
{
    // override note property with static value
    c.Property(p => p.Note).Value("Testing static value");
});
```

## Data Sources

### Primitive Value Data Sources

**BooleanSource** - Random true or false   
**DateTimeSource** - Random date plus or minus 10 years from now    
**DecimalSource** - Random decimal between 0 and 1,000,000    
**FloatSource** - Random float between 0 and 1,000,000    
**GuidSource** - Random GUID value    
**IntegerSource** - Random integer between 0 and 32,000    
**ListDataSource** - Random value from the specified list    
**TimeSpanSource** - Random TimeSpan between 0 sec and 1 day    
**ValueSource** - Static value source    

### Smart Data Sources

**CitySource** - Random city name from a list of the largest US cities    
**CompanySource** - Random company name from a list of fortune 500 companies    
**CreditCardSource** - Random credit care number    
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
**SocialSecuritySource** - Random US Social Security Number    
**StateSource** - Random US State    
**StreetSource** - Random US house number and street    
**WebsiteSource** - Random website from top 100 list    
