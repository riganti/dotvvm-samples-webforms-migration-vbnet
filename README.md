# Migrating ASP.NET Web Forms app to .NET Core using DotVVM (VB.NET version)
This sample shows the process of incremental migration of old ASP.NET Web Forms apps to .NET Core using [DotVVM](https://github.com/riganti/dotvvm). 

> See [VB.NET version of the sample](https://github.com/riganti/dotvvm-samples-webforms-migration-vbnet) if you are using VB.NET in your Web Forms app.

![Screenshot](images/wf001.png)

## Prerequisites
* Make sure you have installed [DotVVM for Visual Studio](https://www.dotvvm.com/install)

## How to run the sample

1. **C# version:** [Open the GitHub repo in Visual Studio](git-client://clone/?repo=https%3A%2F%2Fgithub.com%2Friganti%2Fdotvvm-samples-webforms-migration)
or
`git clone https://github.com/riganti/dotvvm-samples-webforms-migration.git`\
**VB.NET version:** [Open the GitHub repo in Visual Studio](git-client://clone/?repo=https%3A%2F%2Fgithub.com%2Friganti%2Fdotvvm-samples-webforms-migration-vbnet)
or
`git clone https://github.com/riganti/dotvvm-samples-webforms-migration-vbnet.git`

2. Switch to the `01_webforms` branch\
![Manage branches](images/wf002.png)
![Switch to the 01_webforms branch](images/wf003.png)

3. Open `src/OldWebApp/OldWebApp.sln`\
![Open the solution file](images/wf004.png)

4. Right-click `OldWebApp` project and select **View > View in Browser**
![View OldWebApp in Browser](images/wf005.png)

5. Review the functionality of the Web Forms application that is going to be modernized.

6. Checkout other branches to see the steps of the modernization process:
    * `02_install_dotvvm` � DotVVM packages have been installed in the project
    * `03_migration_in_progress` � `About` page was rewritten into DotVVM, `Default` page stays in Web Forms
    * `04_migration_complete` � `Default` page was rewritten into DotVVM, the project is ready to be switched to .NET Core
    * `05_dotnetcore` � The project `CSPROJ` file was changed to the new .NET Core syntax

## What you can learn in the sample

* How to use DotVVM together with ASP.NET Web Forms in the same application
* See the differences between DotHTML and ASPX syntax (see [Cheat Sheet](https://www.dotvvm.com/webforms) for more info)
* See how to use GridViewDataSet to implement paging and sorting in the GridView control

---

[![Move your Web Forms app to .NET Core without rewriting everything](https://raw.githubusercontent.com/riganti/dotvvm-samples-webforms-migration/master/video_thumb.png)](https://channel9.msdn.com/Events/dotnetConf/NET-Conf-2019/B321)

[DotVVM](https://github.com/riganti/dotvvm) is an open source MVVM framework for web applications that supports ASP.NET and ASP.NET Core. 

There are still plenty of old Web Forms applications out in the world. They are difficult to maintain and extend. The authors of such apps stand in front of a difficult choice:
* to rewrite the entire application from scratch using a modern stack
* to start a long-running modernization process and do it "on the fly" using small, incremental updates 

The total rewrite is a timely process. It requires a huge effort, it is often hard to get approved by company management, and requires the developers to adopt a lot of new knowledge. Morover, it is difficult for the team to add new features in the application as they have a lot of work with the rewrite.

The second way, which is demonstrated by this sample, is less risky, involves less effort and allows to split the modernization into smaller parts so the team can split its capacity to satisfy both modernization and adding new features. DotVVM is also similar to Web Forms in many ways and doesn't require extensive knowledge of JavaScript, so it is very easy to adopt to any .NET developer.

> This sample shows how to migrate ASP.NET Web Forms applications written in VB.NET. Since there are known issues with the _DotVVM for Visual Studio_ extension in VB.NET projects, this sample shows how to create C# DotVVM project next to the VB.NET project and uses DotVVM with C#. However, the business layer of the application will stay in VB.NET.

> See the [C# version of the sample](https://github.com/riganti/dotvvm-samples-webforms-migration) if you are using C# in your Web Forms app.

## The process of modernization

This sample demonstrates how DotVVM can be used in the process of incremental modernization of Web Forms applications. Every step of the process can be seen by checking out one of the repository branches. 

### Step 1: The `01_webforms` branch contains a simple ASP.NET Web Forms application (in VB.NET) with a few pages and a simple usage of the `GridView` control.

### Step 2: The `02_install_dotvvm` branch shows how to install DotVVM in the project.

* Create a new DotVVM project aside of the VB.NET project (e.g. `OldWebApp.DotVVM`).
* Add the relative path to the DotVVM project in the `appSettings` section in the `web.config` in the Web Forms project:

```
  <appSettings>
    <add key="dotvvm:AppLocation" value="..\OldWebApp.DotVVM" />
  </appSettings>
```

* Add the reference to the DotVVM project in the Web Forms project.
* Install `DotVVM.Owin` package in the Web Forms project.
* Install `Microsoft.Owin.Host.SystemWeb` package in the Web Forms project.
* Add the OWIN Startup Class [Startup.vb](https://github.com/riganti/dotvvm-samples-webforms-migration-vbnet/blob/02_install_dotvvm/src/OldWebApp/OldWebApp/Startup.vb) in the Web Forms project.
* Remove any routing rules from the [DotvvmStartup.cs](https://github.com/riganti/dotvvm-samples-webforms-migration-vbnet/blob/02_install_dotvvm/src/OldWebApp/OldWebApp.DotVVM/DotvvmStartup.cs)
* Remove the OWIN Startup Class `Startup.cs` from the DotVVM project.

Now you can create new pages in the application using DotVVM, and start an incremental upgrade of the ASPX pages to DotVVM. See the [differences cheat-sheet](https://www.dotvvm.com/webforms) to learn about the differences between DotVVM and ASP.NET Web Forms.

### Step 3: The `03_migration_in_progress` branch shows some pages migrated to DotVVM while the rest remains in ASP.NET Web Forms.

* A master page [Site.dotmaster](https://github.com/riganti/dotvvm-samples-webforms-migration-vbnet/blob/03_migration_in_progress/src/OldWebApp/OldWebApp.DotVVM/Views/Site.dotmaster) was created. Its content was copied with a few changes made: `asp:ContentPlaceHolder` was changed to `dot:ContentPlaceHolder`, all the `runat="server"` were removed and so on. 
* A viewmodel [SiteViewModel.cs](https://github.com/riganti/dotvvm-samples-webforms-migration-vbnet/blob/03_migration_in_progress/src/OldWebApp/OldWebApp.DotVVM/ViewModels/SiteViewModel.cs) with an abstract property `Title` was added in the project. 
* A resources for jQuery and Bootstrap were configured in [DotvvmStartup.cs](https://github.com/riganti/dotvvm-samples-webforms-migration-vbnet/blob/03_migration_in_progress/src/OldWebApp/OldWebApp.DotVVM/DotvvmStartup.cs).
* The [About.dothtml](https://github.com/riganti/dotvvm-samples-webforms-migration-vbnet/blob/03_migration_in_progress/src/OldWebApp/OldWebApp.DotVVM/Views/About.dothtml) page was migrated in the DotVVM project and removed from the Web Forms project.
* The route registrations for the migrated pages were moved from [Global.asax.vb](https://github.com/riganti/dotvvm-samples-webforms-migration-vbnet/blob/03_migration_in_progress/src/OldWebApp/OldWebApp/Global.asax.vb) to [DotvvmStartup.cs](https://github.com/riganti/dotvvm-samples-webforms-migration-vbnet/blob/03_migration_in_progress/src/OldWebApp/OldWebApp.DotVVM/DotvvmStartup.cs).

The deployment model of the application remains the same - you don't need to change anything. This stage can take a long time as there may be hundreds of pages in the application.

During the migration, you can make another refactorings, and thanks to the MVVM approach of DotVVM, your viewmodels will be testable. This can improve the further maintainability of the application.

Since the DotVVM project is refefenced from the Web Forms project, the business logic in the Web Forms project needs to be moved in a separate class library so it can be used from both projects. This is demonstrated in the next step - the `Model` folder was moved to a separate project.

Refer to the [Cheat Sheet for Web Forms developers](https://www.dotvvm.com/webforms), and check out [ASPX Converter](https://www.dotvvm.com/webforms/convert) which can help with some conversions of ASPX markup into DotHTML syntax.

### Step 4: The `04_migration_complete` branch shows all the pages migrated to DotVVM.

* The [Default.dothtml](https://github.com/riganti/dotvvm-samples-webforms-migration-vbnet/blob/04_migration_complete/src/OldWebApp/OldWebApp.DotVVM/Views/Default.dothtml) was migrated and demonstrates the [GridView](https://www.dotvvm.com/docs/controls/builtin/GridView/latest) and [DataPager](https://www.dotvvm.com/docs/controls/builtin/DataPager/latest) controls in DotVVM. 
* The [DefaultViewModel.cs](https://github.com/riganti/dotvvm-samples-webforms-migration-vbnet/blob/04_migration_complete/src/OldWebApp/OldWebApp.DotVVM/ViewModels/DefaultViewModel.cs) demonstrates the MVVM approach for data-binding and the usage of `GridViewDataSet`.

The viewmodel was using the business logic that was present in the `Model` folder. This logic was moved to the class library project so it can be used from both Web Forms and DotVVM apps.

At the end of this stage, the application doesn't use any of the ASP.NET Web Forms features, so it's ready to be switched to .NET Core.
In real-world applications, there might be some other things to change like authentication (needs to be migrated to ASP.NET Core authentication libraries), bundling and more. All these things will need to be addressed during the next step.

### Step 5: The `05_dotnetcore` branch shows the changes made to the project file in order to switch the project to .NET Core 3.0.

* The [OldWebApp.NetCore.csproj](https://github.com/riganti/dotvvm-samples-webforms-migration-vbnet/blob/05_dotnetcore/src/OldWebApp/OldWebApp.NetCore/OldWebApp.NetCore.csproj) was converted to the new format and the `Dotvvm.Owin` package was replaced by `Dotvvm.AspNetCore`.
* The scripts and CSS files were moved to the `wwwroot` folder.
* The [Startup.cs](https://github.com/riganti/dotvvm-samples-webforms-migration-vbnet/blob/05_dotnetcore/src/OldWebApp/OldWebApp.NetCore/Startup.cs) was updated to use the ASP.NET Core `IServiceCollection` and `IAppBuilder`.

Switching to .NET Core may require additional configuration steps on the server to be performed. Make sure you plan this process in advance so the upgrade process is smooth.

## Conclusion

As you can see, the migration is not easy - there is no magic wizard that will just "convert" the application from ASP.NET Web Forms. However, this method allows to migrate the application while new features can be added continuously, and means much less effort than a total rewrite. You can also learn DotVVM on the fly, start with simple pages and continue with the complex ones. 

---

## Other resources

* [Gitter Chat](https://gitter.im/riganti/dotvvm)
* [DotVVM Official Website](https://www.dotvvm.com)
* [DotVVM Documentation](https://www.dotvvm.com/docs)
* [DotVVM GitHub](https://github.com/riganti/dotvvm)
* [Twitter @dotvvm](https://twitter.com/dotvvm)
* [Samples](https://www.dotvvm.com/samples)
* [Cheat-sheet for Web Forms developers](https://www.dotvvm.com/webforms)
* [ASPX Converter](https://www.dotvvm.com/webforms/converter)


 

 