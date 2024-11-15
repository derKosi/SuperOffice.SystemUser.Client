# SystemUser.Client.tests

This project contains the tests for the SystemUser.Client project.

The project contains two files which needs to be configured:
1. appsettings.example.json -> copy and rename to appsettings.json
2. privateKey.example.xml -> copy and rename to privateKey.xml

appsetting.json and privateKey.xml are both added to .gitignore, to prevent actuall values to be uploaded to github.

## Running the tests

1. Update appsettings.json with your settings
2. Add your privateKey, that is the private key for the application, to privateKey.xml
3. Make sure both appsettings.json and privateKey.xml are set to copy to the output directory. They can either be added through Visual Studio interface, or by editing the .csproj file directly. Example:

    ```xml
    <ItemGroup>
    <None Update="appsettings.json">
      <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    </None>
    <None Update="privateKey.xml">
      <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    </None>
  </ItemGroup>

 4. Run the test `Test_Configuration`, this will validate that you have set up the project correctly.



