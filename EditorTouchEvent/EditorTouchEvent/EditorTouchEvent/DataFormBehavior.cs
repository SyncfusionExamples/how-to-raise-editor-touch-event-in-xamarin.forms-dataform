using Syncfusion.XForms.DataForm;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace EditorTouchEvent
{
    public class DataFormBehavior : Behavior<ContentPage>
    {

        SfDataForm dataForm;
        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            dataForm = bindable.FindByName<SfDataForm>("dataForm");
            dataForm.DataObject = new ContactInfo();
            dataForm.RegisterEditor("Entry", new CustomViewEditor(dataForm));
            dataForm.RegisterEditor("ContactNumber", "Entry");
            dataForm.IsReadOnly = true;
        }
    }

    public class ContactInfo
    { 
        public string Name { get; set; }
        public string Address { get; set; }
        [Display(Name = "Contact Number")]
        public int ContactNumber { get; set; }
        public string Email { get; set; }
    }
}
