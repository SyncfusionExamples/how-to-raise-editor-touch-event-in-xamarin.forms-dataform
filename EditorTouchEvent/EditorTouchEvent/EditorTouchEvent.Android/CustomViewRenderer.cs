using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using EditorTouchEvent;
using EditorTouchEvent.Droid;
using Syncfusion.Android.PopupLayout;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly: ExportRenderer(typeof(CustomView), typeof(CustomViewRenderer))]
namespace EditorTouchEvent.Droid
{
    public class CustomViewRenderer : ViewRenderer
    {
        EditText editText;
        SfPopupLayout popupLayout;
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
        {
            base.OnElementChanged(e);
            editText = new EditText(this.Context);
            editText.Touch += OnEditTextTouch;

            popupLayout = new SfPopupLayout(this.Context);
            EditText popupContentView = new EditText(this.Context) { Hint = "Please enter the contact number" };
            popupContentView.SetTextColor(Android.Graphics.Color.Black);
            popupLayout.PopupView.ContentView = popupContentView;
            popupLayout.PopupView.ShowHeader = false;
            popupLayout.PopupView.AcceptButtonText = "Ok";

            LinearLayout linearLayout = new LinearLayout(this.Context);
            linearLayout.Orientation = Orientation.Vertical;
            linearLayout.Enabled = false;
            linearLayout.AddView(popupLayout);
            linearLayout.AddView(editText);
            this.SetNativeControl(linearLayout);
        }

        private void OnEditTextTouch(object sender, TouchEventArgs e)
        {
            popupLayout.Show();
        }
    }
}