using Godot;
using System;

public partial class BaseShopButton : Button
{
    [Export] private string _buttonText { get; set; } = "(InserButtonText)";
    [Export] private string _buttonInfo { get; set; } = "(InsertInfoText)";
 
    [Export] private float _valueMultp { get; set; } = 1.2f;

    [Export] private Color _buttonColor { get; set; } = new Color("White");

    private Label _label = null;

    public override void _Ready() {
        _label = GetNode<Label>("ButtonText");
        _label.Text = _buttonText;
    }

    public void SendInfo() {
        var infoText = GetNode<TextEdit>("/root/Shop/InfoText");
        if (infoText == null)
        {
            GD.PrintErr("ERROR BaseShopButton: No info text found!");
            return;
        }
        else
            infoText.Text = _buttonInfo;
    }

}
