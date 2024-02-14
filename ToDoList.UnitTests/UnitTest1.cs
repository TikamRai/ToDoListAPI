namespace ToDoList.UnitTests;
using Xunit;

public class UnitTest1
{
    [Fact]
    public void ToDoItems_Constructor_InitializesPropertiesCorrectly()
    {
        var id = 1;
        var name = "Sample Task";
        var description = "This is a sample task";

        var toDoItems = new ToDoList.Model.ToDoItems { Id = id, Name = name, Description = description };

        Assert.Equal(id, toDoItems.Id);
        Assert.Equal(name, toDoItems.Name);
        Assert.Equal(description, toDoItems.Description);
    }

    [Fact]
    public void ToDoItem_CompletedDate_CanBeSetAndGet()
    {
        var toDoItems = new ToDoList.Model.ToDoItems();
        var doneDate = DateTime.Now;

        toDoItems.DoneDate = doneDate;

        Assert.Equal(doneDate, toDoItems.DoneDate);
    }

    [Fact]
    public void ToDoItem_Id_CanBeSetAndGet()
    {
        var toDoItems = new ToDoList.Model.ToDoItems();
        var id = 1;

        toDoItems.Id = id;

        Assert.Equal(id, toDoItems.Id);
    }

    [Fact]
    public void ToDoItem_Name_CanBeSetAndGet()
    {
        var toDoItems = new ToDoList.Model.ToDoItems();
        var name = "Sample Task";

        toDoItems.Name = name;

        Assert.Equal(name, toDoItems.Name);
    }
}