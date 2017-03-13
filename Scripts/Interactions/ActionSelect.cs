
public class ActionSelect : Interaction
{
    public override void deselect()
    {
        ActionsManager.current.clearButtons();
        ActionsManager.current.addPlayerButtons();
    }

    public override void select()
    {
        ActionsManager.current.clearButtons();

        foreach(var ab in GetComponents<ActionBehavior>())
        {
            if(ab.showOnSelect)
            {
                ActionsManager.current.addButton(ab.buttonImage, ab.getClickAction());
            }
        }
    }
}
