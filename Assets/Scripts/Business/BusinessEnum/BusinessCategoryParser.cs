public class BusinessCategoryParser
{
    public string BusinessCategory;

    public void BusinessCategoryParseToString(BusinessCategoryEnum.BusinessCategory businessCategory)
    {
        switch (businessCategory)
        {
            case BusinessCategoryEnum.BusinessCategory.FoodIndustry:
                BusinessCategory = "Food Industry";
                break;
            case BusinessCategoryEnum.BusinessCategory.Manufacture:
                BusinessCategory = "Manufacture";
                break;
            case BusinessCategoryEnum.BusinessCategory.Transportation:
                BusinessCategory = "Transportation";
                break;
        }
    }
}
