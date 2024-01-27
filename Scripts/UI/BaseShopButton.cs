using Godot;
using System;

public partial class BaseShopButton : Button
{
    enum Skills
    {
        MovementSpeed,
        AttackSpeed,
        AttackSize
    }

    //[Export] private string _buttonText { get; set; } = "(InsertButtonText)";
    [Export] private Skills _skill { get; set; } = Skills.MovementSpeed;
    [Export] private string _buttonInfo { get; set; } = "(InsertInfoText)";

    [Export] private float _valueMultp { get; set; } = 1.2f;

    [Export] private Color _buttonColor { get; set; } = new Color("White");

    private Label _label = null;

    public override void _Ready() {

        _label = GetNode<Label>("ButtonText");

        switch (_skill)
        {
            case Skills.MovementSpeed:
                _label.Text = "Movement speed";
                break;
            case Skills.AttackSpeed:
                _label.Text = "Attack speed";
                break;
            case Skills.AttackSize:
                _label.Text = "Attack size";
                break;
            default:
                _label.Text = "(InsertCorrectText)";
                break;
        }

    }

    public void ButtonHoverInfo() {
        var parentPath = GetParent().GetPath();
        var infoText = GetNode<TextEdit>($"{parentPath}/InfoText");
        if (infoText == null)
        {
            GD.PrintErr("ERROR BaseShopButton: No info text found!");
            return;
        }
        else
            infoText.Text = _buttonInfo;
    }

    public void OnPressed() {
        var player = (CharacterController)GetTree().CurrentScene.FindChild("PlayerCharacter");
        if (player == null)
        {
            GD.PrintErr("ERROR BaseShopButton: Player not found!");
            GetTree().Paused = false;
            GetParent().QueueFree();
            return;
        }
        else
        {
            UpdateSkill(player);
            GetTree().Paused = false;
            GetParent().QueueFree();
        }
    }

    public void UpdateSkill(CharacterController player)
    {
        switch (_skill)
        {
            case Skills.MovementSpeed:
                break;
            case Skills.AttackSpeed:
                break;
            case Skills.AttackSize:
                break;
        }
    }
}
