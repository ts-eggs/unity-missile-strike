using UnityEngine;

public class ShowUnitInfo : Interaction
{

    public string unitName;

    public string unitDescription;

    public float maxHealth, currentHealth;

    public Sprite profileImage;

    private bool isSelected = false;

    public void setCurrentHealth(float ch)
    {
        currentHealth = ch;

        if(isSelected)
        {
            InfoManager.current.setLines(unitName, unitDescription, currentHealth + "/" + maxHealth);
        }
    }
    
    public override void deselect()
    {
        isSelected = false;
        InfoManager.current.clear();
    }

    public override void select()
    {
        isSelected = true;
        InfoManager.current.setImage(profileImage);
        InfoManager.current.setLines(unitName, unitDescription, currentHealth + "/" + maxHealth);
    }
}
