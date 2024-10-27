namespace DCXAirTest.Domain.Core
{
    using AutoMapper;
    using DCXAirTest.Domain.Entity.General;
    using DCXAirTest.Domain.Entity.ValueObject;
    using DCXAirTest.Domain.Interface;
    using DCXAirTest.Domain.Repository;
    using System;
    using System.Collections.Generic;

    public class FlightDomain : IFlightDomain
    {
        private readonly IMapper _mapper;
        private readonly IFlightRepository _flightRepository;

        public FlightDomain(IMapper mapper, IFlightRepository flightRepository)
        {
            _mapper = mapper;
            _flightRepository = flightRepository;
        }

        public async Task<List<Journey>> GetJourneysOneWayAsync(string origin, string destination, string currency)
        {
            //Mapeo de entidad
            var totalFlight = await _flightRepository.GetJourneysOneWayAsync();

            // Lista para almacenar los journeys finales
            var journeys = new List<Journey>();
            var tempFligth = new List<Flight>();


            // Filtrar vuelos por origen
            var OriginFilter = totalFlight.Where(x => x.Origin == origin);

            // Filtrar vuelos por destino
            var destinationFilter = totalFlight.Where(x => x.Destination == destination);

            journeys = searchRecursive(journeys, OriginFilter, totalFlight, destinationFilter, origin, destination);

            return journeys;
        }

        public async Task<List<Journey>> GetJourneysRoundTripAsync(string origin, string destination, string currency)
        {
            //Mapeo de entidad
            var totalFlight = await _flightRepository.GetJourneysRoundTripAsync();

            // Lista para almacenar los journeys finales
            var journeys = new List<Journey>();
            var journeysRound = new List<Journey>();
            var tempFligth = new List<Flight>();

            // Filtrar vuelos por origen
            var OriginFilter = totalFlight.Where(x => x.Origin == origin);

            // Filtrar vuelos por destino
            var destinationFilter = totalFlight.Where(x => x.Destination == destination);

            // viaje de ida
            journeys = searchRecursive(journeys, OriginFilter, totalFlight, destinationFilter, origin, destination);

            // Filtrar vuelos por origen
            var OriginFilterRound = totalFlight.Where(x => x.Origin == destination);

            // Filtrar vuelos por destino
            var destinationFilterRound = totalFlight.Where(x => x.Destination == origin);

            // viaje de vuelta
            journeysRound = searchRecursive(journeys, OriginFilterRound, totalFlight, destinationFilterRound, destination, origin);

            journeys.AddRange(journeysRound);

            return journeys;
        }

        public List<Journey> searchRecursive(List<Journey> journeys,IEnumerable<Flight> OriginFilter, IEnumerable<Flight> totalFlight,
            IEnumerable<Flight> destinationFilter
            ,string origin, string destination)
        {
            // no es lo mas optimo pero seria meter la recursividad de los vuelos en este lugar 
            // en este caso como hay pocos datos se hara hasta 2 escalas y por el tiempo
            foreach (var ori in OriginFilter)
            {
                foreach (var des in destinationFilter)
                {
                    if (ori.Origin == des.Origin && ori.Destination == des.Destination)
                    {
                        // scala directa
                        journeys.Clear();
                        var journe = new Journey
                        {
                            Origin = origin,
                            Destination = destination,
                            Price = (decimal)ori.Price,
                            Flights = new List<Flight>()
                        };

                        var flightOriDirect = new Flight
                        {
                            Origin = ori.Origin,
                            Destination = ori.Destination,
                            Price = ori.Price,
                            Transport = new Transport
                            {
                                FlightCarrier = ori.Transport.FlightCarrier,
                                FlightNumber = ori.Transport.FlightNumber
                            }
                        };
                        journe.Flights.Add(flightOriDirect);
                        journeys.Add(journe);
                        return journeys;
                    }else if (ori.Destination == des.Origin || ori.Destination == des.Destination)
                    {
                        var journey = new Journey
                        {
                            Origin = origin,
                            Destination = destination,
                            Price = (decimal)ori.Price + (decimal)des.Price,
                            Flights = new List<Flight>()
                        };

                        var flightOri = new Flight
                        {
                            Origin = ori.Origin,
                            Destination = ori.Destination,
                            Price = ori.Price,
                            Transport = new Transport
                            {
                                FlightCarrier = ori.Transport.FlightCarrier,
                                FlightNumber = ori.Transport.FlightNumber
                            }
                        };

                        var flightdes = new Flight
                        {
                            Origin = des.Origin,
                            Destination = des.Destination,
                            Price = des.Price,
                            Transport = new Transport
                            {
                                FlightCarrier = des.Transport.FlightCarrier,
                                FlightNumber = des.Transport.FlightNumber
                            }
                        };

                        // Agregar el vuelo a la lista de Flights en Journey
                        journey.Flights.Add(flightOri);
                        journey.Flights.Add(flightdes);
                        journeys.Add(journey);
                    }

                }

                // Filtrar vuelos por origen
                var newOri = totalFlight.Where(x => x.Origin == ori.Destination);

                foreach (var ori2 in newOri)
                {
                    foreach (var des in destinationFilter)
                    {
                        if (ori2.Destination == des.Origin)
                        {
                            var journey1 = new Journey
                            {
                                Origin = origin,
                                Destination = destination,
                                Price = (decimal)ori.Price + (decimal)ori2.Price + (decimal)des.Price,
                                Flights = new List<Flight>()
                            };

                            var flightOri1 = new Flight
                            {
                                Origin = ori.Origin,
                                Destination = ori.Destination,
                                Price = ori.Price,
                                Transport = new Transport
                                {
                                    FlightCarrier = ori.Transport.FlightCarrier,
                                    FlightNumber = ori.Transport.FlightNumber
                                }
                            };

                            var flightOri2 = new Flight
                            {
                                Origin = ori2.Origin,
                                Destination = ori2.Destination,
                                Price = ori2.Price,
                                Transport = new Transport
                                {
                                    FlightCarrier = ori2.Transport.FlightCarrier,
                                    FlightNumber = ori2.Transport.FlightNumber
                                }
                            };

                            var flightOri3 = new Flight
                            {
                                Origin = des.Origin,
                                Destination = des.Destination,
                                Price = des.Price,
                                Transport = new Transport
                                {
                                    FlightCarrier = des.Transport.FlightCarrier,
                                    FlightNumber = des.Transport.FlightNumber
                                }
                            };

                            // Agregar el vuelo a la lista de Flights en Journey
                            journey1.Flights.Add(flightOri1);
                            journey1.Flights.Add(flightOri2);
                            journey1.Flights.Add(flightOri3);
                            journeys.Add(journey1);
                        }
                    }
                }
            }
            return journeys;
        }
    }
}
