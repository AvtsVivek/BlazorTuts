﻿using BlazorApiCall.SharedKernel;

namespace BlazorApiCall.Core.ProjectAggregate.Events;

public class ToDoItemCompletedEvent : DomainEventBase
{
  public ToDoItem CompletedItem { get; set; }

  public ToDoItemCompletedEvent(ToDoItem completedItem)
  {
    CompletedItem = completedItem;
  }
}
