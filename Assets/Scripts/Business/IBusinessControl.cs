using System.Collections.Generic;

public interface IBusinessControl
{ 
    List<BusinessTemplate> BusinessesList();
    void AddNewBusiness(BusinessTemplate business);
    void GetBusinessesList();
}
