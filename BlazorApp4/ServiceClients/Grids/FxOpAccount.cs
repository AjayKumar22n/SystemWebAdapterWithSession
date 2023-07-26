namespace BlazorApp4.ServiceClients
{
    public static class RowTypes
    {
        /*
        public static readonly string SubType = "SUBTYPE";
        public static readonly string Section = "SECTION";
        public static readonly string SubSection = "SUBSECTION";
        public static readonly string Account = "ACCOUNT";
        */
        public static readonly string SubType = "SubType";
        public static readonly string Section = "Section";
        public static readonly string SubSection = "SubSection";
        public static readonly string Account = "Account";
    }

    public abstract class BasePlanAccount
    {
        public string Label { get; set; } // This is not mandatory for the Sub sections
        public required string Constant { get; set; } // Required - Unique for each Row 
        public required string LabelHoverInfo { get; set; } // when user hove on the Label Text 
        public required string RowType { get; set; } // Required, this should be enum of {SubType, Section, SubSection(might not have label), Account }
        //public FxOpRowType FxRowType { get; set; }
        public bool IsEditableAccount { get; set; } // for not highlighing the row with light gray
        public string ParentConstant { get; set; } //Better for future purpose - Account parent might be section constant (uniue for with label and without lable also), section parent is SubType Constant.
        public bool IsHidden { get; set; } = false; // for Group (SubType) which is collapsable. and true.
        public bool IsAccountSpecialStyle { get; set; } = false;

        public required string SubTypeGroup { get; set; }

        //public required bool showColumn { get; set; } = true;
    }
  
}
