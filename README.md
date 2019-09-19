# Cracked.to Authentication

Class library for Cracked.to's official authentication system written in C# - https://cracked.to/auth.php

## Installation

Build solution, install Newtonsoft.Json and System.Management packages and import DLL into your project.

## Example Usage

```csharp
Console.WriteLine("Enter authentication key.");
string authKey = Console.ReadLine();

Auth auth = new Auth();
bool isAuthenticated = auth.Authenticate(authKey, "-1");

Console.WriteLine("Authenticated: " + isAuthenticated);
Console.ReadLine();
```

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License
[MIT](https://choosealicense.com/licenses/mit/)
