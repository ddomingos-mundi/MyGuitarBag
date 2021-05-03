# :guitar: MyGuitarBag

O objetivo do projeto é mostrar como podemos criar um pacote/componente com o NuGet, aproveitando diretamente os contratos definidos internamente nos endpoints da API.

:bug: - Com isso evitamos:

- Duplicação de código
- Contratos desatualizados
- Múltiplos pontos de alteração (desordenados)

:zap: - E ganhamos:

- Versionamento de atualizações
- Padronização nas definições
- Velocidade no desenvolvimento


Com definições bem simples dentro do *.csproj conseguimos "documentar" e configurar nosso componente, tornando o compartilhamento bem rápido e 
confiável.

``` xml
  <PropertyGroup>
    <TargetFramework>netstandard2.0</TargetFramework>
    <Version>0.0.5</Version>
    <PackageLicenseFile>LICENSE.txt</PackageLicenseFile>
    <Authors>Danilo Domingos</Authors>
    <Company>PagarMe</Company>
    <Description>SDK de exemplo para o PagarMe Talks</Description>
    <RepositoryType>public</RepositoryType>
    <RepositoryUrl>https://github.com/ddomingos-mundi/MyGuitarBag</RepositoryUrl>
    <PackageTags>talks sdks apiClient rest</PackageTags>
    <PackageIconUrl>https://github.com/ddomingos-mundi/MyGuitarBag/blob/master/MyGuitarBag.Sdk/Assets/icon.png</PackageIconUrl>
    <PackageIcon>images\icon.png</PackageIcon>
    <Copyright>Copyright 2021</Copyright>
    <RunAnalyzersDuringBuild>true</RunAnalyzersDuringBuild>
    <RunAnalyzersDuringLiveAnalysis>true</RunAnalyzersDuringLiveAnalysis>
  </PropertyGroup>
```

No site oficial do [NuGet](https://www.nuget.org/packages/MyGuitarBag.Sdk/0.0.5) é possível ver esses detalhes, assim como o histórico de publicações e 
estatísticas atualizadas do pacote.

![image](https://user-images.githubusercontent.com/54947912/116838002-21cc7b00-aba3-11eb-8f5e-c94bb7d429f5.png)

O resultado final é gerado pela marcação abaixo:
``` xml

 <ItemGroup>
    <ProjectReference Include="..\MyGuitarBag.Models\MyGuitarBag.Models.csproj">
      <PrivateAssets>all</PrivateAssets> <!-- Esconde o arquivo da lista de dependências -->
    </ProjectReference>
  </ItemGroup>

  <!-- Inclui MyGuitarBag.Models no package -->
  <ItemGroup>
    <None Include="$(OutputPath)\MyGuitarBag.Models.dll" Pack="true">
      <PackagePath>lib\netstandard2.0\</PackagePath>
    </None>
  </ItemGroup>

```

### Como executar o projeto?

Just run! ;)

### Links úteis
- [MyGuitarBag.Sdk](https://www.nuget.org/packages/MyGuitarBag.Sdk/0.0.5)
- [Instalação do NuGet Tools](https://docs.microsoft.com/pt-br/nuget/install-nuget-client-tools)
- [Documentação oficial do NuGet](https://docs.microsoft.com/pt-br/nuget/)
