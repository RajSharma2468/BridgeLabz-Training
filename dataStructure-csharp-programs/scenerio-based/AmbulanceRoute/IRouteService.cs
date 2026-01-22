namespace AmbulanceRoute.Interfaces
{
    interface IRouteService
    {
        void AddUnit();
        void RedirectPatient();
        void RemoveUnit(string unitName);
        void DisplayRoute();
    }
}
