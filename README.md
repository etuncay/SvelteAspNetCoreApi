# SvelteAspNetCoreApi
AspNetCore MVC projesinde sveltejs ile hazırlanmış javascript componentler ile web api den bilgi çeken deneysel projedir.

# Svelte nedir ?
React ve Vue gibi Svelte' te Javascript veya TypeScript kullanarak kullanıcı arayüzleri oluşturmaya yönetlik bir araçtır. Diğer framework'lerin aksine, Svelte kütüphane değil compiler'dır. React sanal DOM tercih ederken Svelte gerçek dum kullanmaktadır.

Daha detaylı bilgi için https://svelte.dev/ adresine bakabilirsiniz.

# Projenin kurulumu
```
dotnet new webapp -o SvelteAspNetCoreApi
```
# package.json ve npm paketleri
```
{
  "name": "SvelteApp",
  "version": "1.0.0",
  "scripts": {
    "build": "rollup -c rollup.config.js"
  },
  "dependencies": {},
  "devDependencies": {
    "@rollup/plugin-node-resolve": "^11.2.0",
    "rollup": "^2.39.0",
    "rollup-plugin-svelte": "^7.1.0",
    "svelte": "^3.32.3"
  }
}
```

# asp.net ve svelte için rollup konfigürasyonları 

```
 import svelte from 'rollup-plugin-svelte';
import resolve from '@rollup/plugin-node-resolve';

export default {
    // This `main.js` file we wrote
    input: 'wwwroot/js/main.js',
    output: {
        // The destination for our bundled JavaScript
        file: 'wwwroot/js/build/bundle.js',
        // Our bundle will be an Immediately-Invoked Function Expression
        format: 'iife',
        // The IIFE return value will be assigned into a variable called `app`
        name: 'app',
    },
    plugins: [
        svelte({
            // Tell the svelte plugin where our svelte files are located
            include: 'wwwroot/**/*.svelte',
            emitCss: false,
            compilerOptions: {
                customElement: true
            }
        }),
        // Tell any third-party plugins that we're building for the browser
        resolve({ browser: true }),
    ]
};
```

# ASP.net core için build edilirken rollup çalışması için gereken kod
```
<Project Sdk="Microsoft.NET.Sdk.Web">

  <PropertyGroup>
    <TargetFramework>net5.0</TargetFramework>
    <CopyRefAssembliesToPublishDirectory>false</CopyRefAssembliesToPublishDirectory>
  </PropertyGroup>

  <Target Name="Rollup" BeforeTargets="Build">
        <Exec Command="npm run build" />
    </Target>

  <ItemGroup>
    <PackageReference Include="Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation" Version="5.0.14" />
  </ItemGroup>

</Project>
```

# Build edildikten sonra oluşan paketi Layout.cshtml'e ekleme
```
<script src="~/js/build/bundle.js" asp-append-version="true"></script>
```