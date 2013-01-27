using AutoMapper;
using EventStreamR.Client.Core.Messages;
using EventStreamR.Server.Domain.Messages;

namespace EventStreamR.Server.Domain.Mapping
{
	public static class ObjectMapping
	{
		 public static void Configure()
		 {
			 Mapper.CreateMap<EventMessage, EventMessageDto>();
		 }
	}
}