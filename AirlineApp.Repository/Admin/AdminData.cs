using AirlineApp.Repository.Model;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineApp.Repository.Admin
{
    public class AdminData : IAdminData
    {
        private readonly airlinedbContext _airlineContext;

        public AdminData(airlinedbContext airlineContext)
        {
            _airlineContext = airlineContext;
        }
        public async Task<bool> AddPassenger(Passenger passenger)
        {
            try
            {
                PassportDetail passportdetail = new PassportDetail();
                if (passenger.PassportDetails != null)
                {    
                    passportdetail = passenger.PassportDetails;
                    await _airlineContext.PassportDetails.AddAsync(passportdetail);
                }
                PassengerStatus passengerstatus = new PassengerStatus();
                passengerstatus = passenger.Status;
                await _airlineContext.PassengerStatuses.AddAsync(passengerstatus);

                int isDataSaved = await _airlineContext.SaveChangesAsync();
                if (isDataSaved > 0)
                {
                    //passenger.PassportDetailsId = passportdetail.PassportDetailsId;
                    passenger.StatusId = passengerstatus.StatusId;
                }
                await _airlineContext.Passengers.AddAsync(passenger);
                int isPassengerDataSaved = await _airlineContext.SaveChangesAsync();
                if (isPassengerDataSaved > 0)
                {
                    return true;
                }
                
            }   
            catch (Exception ex)
            {

                throw ex;
            }
            return false;
        }

        public async Task<bool> UpdatePassenger(Passenger passenger)
        {
            //await _airlineContext.BulkUpdateAsync(passenger);
            try
            {
                Passenger passengerData = await _airlineContext.Passengers.Include(data => data.User).Include(data => data.PassportDetails).
                    FirstOrDefaultAsync(data => data.PassengerId == passenger.PassengerId);
                passengerData.PassengerName = passenger.PassengerName;
                passengerData.Address = string.IsNullOrEmpty(passenger.Address)?passengerData.Address:passenger.Address;
                //passengerData.FlightId = passenger.FlightId;
                if (passenger.PassportDetails != null)
                {
                    passengerData.PassportDetails.PassportNumber = passenger.PassportDetails.PassportNumber;
                    passengerData.PassportDetails.DateOfBirth = passenger.PassportDetails.DateOfBirth;
                    passengerData.PassportDetails.DateOfExpiry = passenger.PassportDetails.DateOfExpiry;
                    passengerData.PassportDetails.DateOfIssue = passenger.PassportDetails.DateOfIssue;
                }
                //passengerData.SeatNumber = passenger.SeatNumber;
                //passengerData.FlightDateTime = passenger.FlightDateTime;
                //passengerData.Status.CheckedIn = passenger.Status.CheckedIn;
                //passengerData.Status.RequiringWheelChair = passenger.Status.RequiringWheelChair;
                //passengerData.Status.PassengerWithInfants = passenger.Status.PassengerWithInfants;
                //passengerData.PassengerServices = passenger.PassengerServices;
                //passengerData.PassengerShopRequests = passenger.PassengerShopRequests;
                //passengerData.PassengerMeals = passenger.PassengerMeals;
                //_airlineContext.Passengers.Attach(passenger);

                int datasaved = await _airlineContext.SaveChangesAsync();
                if (datasaved > 0)
                    return true;
                 
            }
            catch (DbUpdateException ex)
            {

                throw ex;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return false;
        }

        public async Task<bool> DeleteAndUpdateServices(Passenger passenger)
        {
            int dataSaved = 0;
            int isDataProcessing = 0;
            try
            {
                if (passenger.PassengerServices.Count != 0)
                {
                    isDataProcessing++;
                    List<PassengerService> services = await _airlineContext.PassengerServices.Where(data => data.PassengerId == passenger.PassengerId).ToListAsync();

                    _airlineContext.PassengerServices.RemoveRange(services);
                    if (await _airlineContext.SaveChangesAsync() == services.Count)
                    {
                        foreach (PassengerService data in passenger.PassengerServices)
                        {
                            PassengerService passengerservice = new PassengerService();
                            passengerservice.AncillaryServiceId = data.AncillaryServiceId;
                            passengerservice.PassengerId = passenger.PassengerId;
                            await _airlineContext.PassengerServices.AddAsync(passengerservice);
                        }
                        if (await _airlineContext.SaveChangesAsync() == passenger.PassengerServices.Count)
                        {
                            dataSaved++;
                        }
                    }

                }
                if (passenger.PassengerMeals.Count != 0)
                {
                    isDataProcessing++;
                    List<PassengerMeal> meals = await _airlineContext.PassengerMeals.Where(data => data.PassengerId == passenger.PassengerId).ToListAsync();

                    _airlineContext.PassengerMeals.RemoveRange(meals);
                    if (await _airlineContext.SaveChangesAsync() == meals.Count)
                    {
                        foreach (PassengerMeal data in passenger.PassengerMeals)
                        {
                            PassengerMeal passengermeal = new PassengerMeal();
                            passengermeal.MealId = data.MealId;
                            passengermeal.PassengerId = passenger.PassengerId;
                            await _airlineContext.PassengerMeals.AddAsync(passengermeal);
                        }
                        if (await _airlineContext.SaveChangesAsync() == passenger.PassengerMeals.Count)
                        {
                            dataSaved++;
                        }
                    }

                }
                if (passenger.PassengerShopRequests.Count != 0)
                {
                    isDataProcessing++;
                    List<PassengerShopRequest> shopRequests = await _airlineContext.PassengerShopRequests.Where(data => data.PassengerId == passenger.PassengerId).ToListAsync();

                    _airlineContext.PassengerShopRequests.RemoveRange(shopRequests);
                    if (await _airlineContext.SaveChangesAsync() == shopRequests.Count)
                    {
                        foreach (PassengerShopRequest data in passenger.PassengerShopRequests)
                        {
                            PassengerShopRequest passengershoprequest = new PassengerShopRequest();
                            passengershoprequest.ShopRequestId = data.ShopRequestId;
                            passengershoprequest.PassengerId = passenger.PassengerId;
                            await _airlineContext.PassengerShopRequests.AddAsync(passengershoprequest);
                        }
                        if (await _airlineContext.SaveChangesAsync() == passenger.PassengerShopRequests.Count)
                        {
                            dataSaved++;
                        }
                    }

                }

                if (isDataProcessing == dataSaved)
                    return true;
                else if (isDataProcessing >= dataSaved)
                    return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return false;
        }
    }
}
