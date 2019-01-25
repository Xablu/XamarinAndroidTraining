# MvvmCross advanced exercice

For this exercise we will create a whole new solution. 

 We will first install the [MvxScaffolding](https://github.com/Plac3hold3r/MvxScaffolding) extension for Visual Studio:
 
 1. Open Visual Studio
 2. Go to Tools -> Extensions and Updates
 3. Move to the "Online" tab and search for "MvxScaffolding" in the search box
 4. Hit the download button and wait for the extension to download.
 5. When it finishes, close the dialog and then close Visual Studio.
 6. A new window will show up (VSIX Installer). Hit the Modify button and wait until the process ends. The extension will be installed in your IDE.
 7. When it finishes, close the dialog and open Visual Studio again.

 Now that the extension is installed, we have everything we need to create our new projects:

 8. Go to File -> New -> Project 
 9. This time you will see a new category of projects called "MvvmCross". Select it.
 10. You will have two new project/solution templates there: One uses the traditional approach and the other uses Xamarin.Forms. "MvxScaffolding MvvmCross Native" is the one we want to use.
 11. Set the name and solution name to "MvxSample" and hit OK.
 12. A new window with a wizard process will open. Here we can customize several things for our application. The template is telling us which MvvmCross version is going to be installed and it also allows us to change the package name and display name for the app. Leave those as the defaults this time. Do the same for Project Grouping and EditorConfig.
 13. At the right of the window we can choose among three different base apps: Single View, Navigation View and Blank. Please select the "Navigation Menu" option (hit the black circle button) and hit NEXT.
 14. The next step is about configuring each of the projects. For each of these, we can choose if we want to include Unit / UI Tests projects and we can also choose the min SDK version we want to support. Leave everything as default this time (but feel free to play with the different options and possibilities).
 15. Hit NEXT and a summary screen will be displayed. 
 16. Hit DONE and wait for the solution to be created (this might take a while, since a lot of code and packages are going to be added for you).

We will focus on the Core project and the Android projects for the rest of the exercise. You can unload the iOS project if you want (right click on the iOS project -> Unload Project).

17. Run the project! 

18. Locate and open the `App.cs` class in the Core project. This class is responsible for initializing your shared code. You will find it has a method called `Initialize` which will do two things: 1) Bulk register all the interfaces/implementations in the Core assembly that end with "Service" and 2) Register the AppStart as `MainViewModel`. No code needs to be edited this time.

`RegisterAppStart` will let MvvmCross know which ViewModel should be shown first. Would you like to know more about it? [This](https://www.mvvmcross.com/documentation/advanced/customizing-appstart) is the official documentation for it.
 
19. Now please locate the `Setup.cs` class in the Android project. This class can be used to configure and customize most of the MvvmCross components like IoC, Data-Binding engine, ViewPresenter and many others. You can type "override" within the class and use the IntelliSense to see all the methods exposed. No edits for this time.

Now that we have our solution up and running, we can set our goal: We will add a new screen, use Data-Binding and display a polymorphic list.

20. Add a new folder to the Core project. Call it `Models`.
21. Add a new class to the `Models` folder. Call it `City`. Make the class public and add two properties to it: `string Name` and `bool IsCapital`. The result should be the following:

```c#
public class City
{
    public string Name { get; set; }

    public bool IsCapital { get; set; }
}
```

22. Add a new class under the ViewModels folder. Call it `CitiesViewModel`. Make the class public, make it inherit from `MvxViewModel` and define a `MvxObservableCollection<City>` property called `Cities`. Initialize the Cities property as a new empty collection by default.

Note: What is an Observable Collection? It's a very special type of list that will fire changes every time an operation like add, delete, reset or move is run on the list. You can read more about it in the [official](https://docs.microsoft.com/en-us/dotnet/api/system.collections.objectmodel.observablecollection-1?view=netframework-4.7.2) Microsoft documentation. The Mvx version has a few improvements and assumptions (the MvvmCross implementation is optional).

23. Override the `Initialize` method and add some mock items to the list. You can take the following list as an example:

```c#
Cities.Add(new City { Name = "Paris", IsCapital = true });
Cities.Add(new City { Name = "Amsterdam", IsCapital = true });
Cities.Add(new City { Name = "Frankfurt", IsCapital = false });
Cities.Add(new City { Name = "New York", IsCapital = false });
Cities.Add(new City { Name = "Buenos Aires", IsCapital = true });
Cities.Add(new City { Name = "Barcelona", IsCapital = false });
Cities.Add(new City { Name = "Washington DC", IsCapital = true });
Cities.Add(new City { Name = "Tokio", IsCapital = true });
Cities.Add(new City { Name = "Vancouver", IsCapital = false });
```

In the end, `CitiesViewModel` should look something like this:

```c#
public class CitiesViewModel : MvxViewModel
{
    public override Task Initialize()
    {
        Cities.Add(new City { Name = "Paris", IsCapital = true });
        Cities.Add(new City { Name = "Amsterdam", IsCapital = true });
        Cities.Add(new City { Name = "Frankfurt", IsCapital = false });
        Cities.Add(new City { Name = "New York", IsCapital = false });
        Cities.Add(new City { Name = "Buenos Aires", IsCapital = true });
        Cities.Add(new City { Name = "Barcelona", IsCapital = false });
        Cities.Add(new City { Name = "Washington DC", IsCapital = true });
        Cities.Add(new City { Name = "Tokio", IsCapital = true });
        Cities.Add(new City { Name = "Vancouver", IsCapital = false });

        return base.Initialize();
    }

    public MvxObservableCollection<City> Cities { get; set; } = new MvxObservableCollection<City>();
}
```

24. Open `MenuViewModel` 
25. Add a new `IMvxAsyncCommand` property, same as the others you can find in the class. Call it `ShowCitiesCommand`.
26. Create a private method called `NavigateToCitiesAsync` and navigate to `CitiesViewModel` within it, using the MvxNavigationService.
27. In the constructor of MenuViewModel, instantiate the IMvxAsyncCommand, same as the others, so that it calls to your newly added method `NavigateToCitiesAsync`.
28. That's all we need to do for the Core project, let's now move back to the Android project.

29. Open the file `navigation_drawer.xml` within the `Resources\menu` folder.
30. Add a new menu item within the `nav_items` group for our new option. You can use the following code:

```xml
<item
    android:id="@+id/nav_cities"
    android:title="Cities" />
```

31. Open `MenuFragment` and add a new `case` statement in the `OnNavigationItemSelected` method for our newly created option. Make a call to the `ShowCitiesCommand` from there. The result is the following:

```c#
public bool OnNavigationItemSelected(IMenuItem menuItem)
{
    switch (menuItem.ItemId)
    {
        case Resource.Id.nav_home:
            ViewModel.ShowHomeCommand.Execute();
            break;
        case Resource.Id.nav_settings:
            ViewModel.ShowSettingsCommand.Execute();
            break;
        case Resource.Id.nav_cities:
            ViewModel.ShowCitiesCommand.Execute();
            break;
    }

    (Activity as IDrawerActivity)?.DrawerLayout.CloseDrawers();
    return true;
}
```


32. Add a new class inside the `Views` folder. Call it `CitiesView`.
33. Remove the code for the class and replace it for the following content:

```c#
[MvxFragmentPresentation(typeof(MainContainerViewModel), Resource.Id.content_frame)]
public class CitiesView : BaseFragment<CitiesViewModel>
{
    protected override int FragmentLayoutId => Resource.Layout.CitiesView;
}
```

Note: We are going to ask the ViewPresenter to display CitiesView as a fragment in the FrameLayout with ID = content_frame.

34. For this exercise we will use the RecyclerView component. Please install the NuGet package `MvvmCross.Droid.Support.V7.RecyclerView` in your Android project only.
35. Add a new Android Layout within the `Resources\Layout` folder. Call it `CitiesView.axml`.
36. Add a `MvxRecyclerView` widget to your .axml layout (inside the default provided `LinearLayout`):

```xml
<?xml version="1.0" encoding="utf-8"?>
<LinearLayout xmlns:android="http://schemas.android.com/apk/res/android"
	xmlns:local="http://schemas.android.com/apk/res-auto"
    android:orientation="vertical"
    android:layout_width="match_parent"
    android:layout_height="match_parent">
    <mvvmcross.droid.support.v7.recyclerview.MvxRecyclerView
		android:layout_width="match_parent"
		android:layout_height="match_parent"/>
</LinearLayout>
```

37. Add two more layouts: `item_city.axml` and `item_capital.axml`. We will use different "row styles" for our data. In other words, we want capitals and normal cities to look different in the list. This is just a basic example but in real world app you can make your rows look entirely different.

We will define a LinearLayout ViewGroup and a single TextView. Feel free to customize the look and feel for the TextView, or just take the following example:

```c#
<?xml version="1.0" encoding="utf-8"?>
<LinearLayout
	xmlns:android="http://schemas.android.com/apk/res/android"
	xmlns:local="http://schemas.android.com/apk/res-auto"
	android:layout_width="match_parent"
	android:layout_height="wrap_content"
	android:orientation="vertical">
	<TextView
		android:layout_width="wrap_content"
		android:layout_height="wrap_content"
		android:layout_margin="16dp"
		android:textStyle="bold"
		android:textSize="16sp"
		android:textColor="#0000ff"
		local:MvxBind="Text Name" />
</LinearLayout>
```

38. Set the same content for the two recently created layouts. Just make sure you use different text colors, so that you can tell the difference in runtime.
39. Make sure you add a binding statement to your TextView in the item layouts (if you used the example above, it's already there). We want to bind the text of the TextView to the Name of the City we are displaying.

Note: It is highly recommended that if Data-Binding is new to you, you spend a couple of minutes reading the [official documentation](https://www.mvvmcross.com/documentation/fundamentals/data-binding) of MvvmCross for bindings (only the first parts).

40. We have finished the necessary work for the RecyclerView row templates. The next thing we want to do is to add a template selector, so that the RecyclerView knows which row template to use for each case.

Note: Actually, the internal Adapter is going to use the template selector, not the RecyclerView widget.

41. Add a new folder to the Android project and call it `TemplateSelectors`. Then add a new class named `CitiesTemplateSelector`.
42. Make the class public and make it implement the `IMvxTemplateSelector` interface. Implement the necessary methods. In the `GetItemLayoutId` you can just return the parameter that arrives to the method - we don't really need to use that method.
43. For the `GetItemViewType` method, first cast the object parameter to a `City` object and then depending on whether the city is a capital or not, return the correct Layout ID.

The final implementation should be something like this:

```c#
public class CitiesTemplateSelector : IMvxTemplateSelector
{
    public int ItemTemplateId { get; set; }

    public int GetItemLayoutId(int fromViewType)
    {
        return fromViewType;
    }

    public int GetItemViewType(object forItemObject)
    {
        var city = (City)forItemObject;
        return city.IsCapital ? Resource.Layout.item_capital : Resource.Layout.item_city;
    }
}
```

44. Now the last step is about connecting all the pieces in the RecyclerView widget. Please open the layout file `CitiesView` again.
45. We need to let the RecyclerView know which is going to be the TemplateSelector for the list. Add the following sentence inside of it's declaration: `local:MvxTemplateSelector="MvxSample.Droid.TemplateSelectors.CitiesTemplateSelector,MvxSample.Droid"`. Note: If your namespace is different, you might need to tweak the statement.

The first part is pointing to the class that defines the template selection, while the part after the "," is locating the assembly where the template selector is defined.

46. Bind the ItemsSource of the list to the `Cities` collection we created in the ViewModel: `local:MvxBind="ItemsSource Cities;"`.

The final version of the CitiesView.axml layout file is:

```xml
<?xml version="1.0" encoding="utf-8"?>
<LinearLayout xmlns:android="http://schemas.android.com/apk/res/android"
    xmlns:local="http://schemas.android.com/apk/res-auto"
    android:orientation="vertical"
    android:layout_width="match_parent"
    android:layout_height="match_parent">
    <mvvmcross.droid.support.v7.recyclerview.MvxRecyclerView
		android:layout_width="match_parent"
		android:layout_height="match_parent"
		local:MvxTemplateSelector="MvxSample.Droid.TemplateSelectors.CitiesTemplateSelector,MvxSample.Droid"
        local:MvxBind="ItemsSource Cities;" />
</LinearLayout>
```

47. At this point we have finished the work. Run the app!

Where to go from there? Extra step:

48. Let's use a ValueConverter in one of our row styles!
49. Create a new folder in the Core project named `Converters`
50. Add a new class within that folder, call it `CapitalTextToUpperConverter`
51. Make the class public and make it inherit from `MvxValueConverter`.
52. Override the Convert method and change the return statement so that it returns `value.ToString().ToUpper();`.
53. Use the converter. Open `item_capital.axml` and change the data binding sentence so that the path for the binding is `CapitalTextToUpper(Name)`.

Note: Does MvvmCross automatically register my converters in the Data-Binding engine? Yes! You can turn this feature off, but it will do it by default.

54. Run the app!