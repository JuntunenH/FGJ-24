using Godot;
using System;

public partial class BaseMenuButton : Button
{
    [Export] private string _buttonText = "Empty";

    private Label _labelText;

    public override void _Ready()
    {
        _labelText = GetNode<Label>("ButtonText");
        _labelText.Text = _buttonText;
    }
}
