using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreGraphics;
using Foundation;
using Syncfusion.iOS.PopupLayout;
using UIKit;
using Xamarin.Forms.Platform.iOS;

namespace EditorTouchEvent.iOS
{
    public class CustomViewRenderer : ViewRenderer
    {

        SfPopupLayout popupLayout;
        CustomUIView customView;
        UIButton showPopupButton;
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
        {
            base.OnElementChanged(e);
            popupLayout = new SfPopupLayout();
            UITextField popupContentView = new UITextField() { Placeholder = "Please enter the contact number" };
            popupContentView.TextColor = UIColor.Black;
            popupContentView.BackgroundColor = UIColor.White;
            popupLayout.PopupView.ContentView = popupContentView;
            popupLayout.BackgroundColor = UIColor.White;
            popupLayout.PopupView.ShowHeader = false;
            popupLayout.PopupView.AcceptButtonText = "Ok";
            popupLayout.Content = GetContentOfPopup();
            this.SetNativeControl(popupLayout);
        }
        private UIView GetContentOfPopup()
        {
            customView = new CustomUIView();
            customView.BackgroundColor = UIColor.White;

            showPopupButton = new UIButton();
            showPopupButton.TouchDown += OnShowPopupButtonTouchDown;

            customView.AddSubview(showPopupButton);
            return customView;
        }
        void OnShowPopupButtonTouchDown(object sender, EventArgs e)
        {
            popupLayout.Show();
        }
        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            popupLayout.Frame = new CGRect(0, 20, 500, 200);
        }
    }
    public class CustomUIView : UIView
    {
        public CustomUIView() : base()
        {
        }
        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            this.Subviews[0].Frame = new CGRect(0, 0, this.Frame.Right, 50);
        }
    }
}