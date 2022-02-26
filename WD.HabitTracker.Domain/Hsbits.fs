module WD.HabitTracker.Domain.Habits

open System

type BinaryStamp = {
    Date: DateTime
    IsChecked: bool
}

type QuantifiableStamp = {
    Date: DateTime
    Value: int
}

type WeekPlan = {
    Monday: bool
    Tuesday: bool
    Wednesday: bool
    Thursday: bool
    Friday: bool
    Saturday: bool
    Sunday: bool
}

type Hours = int

type Minutes = int

type TimeOfDay = {
    Hours: Hours
    Minutes: Minutes
}

type NotificationSettings = {
    TimeOfDay: TimeOfDay
    Message: string
}

type BinaryHabit = {
    Name: string
    StartDate: DateTime
    WeekPlan: WeekPlan
    Stamps: BinaryStamp list
    NotificationSettings: NotificationSettings option
}

type QuantifiableHabit = {
    Name: string
    StartDate: DateTime
    WeekPlan: WeekPlan
    Stamps: QuantifiableStamp list
    NotificationSettings: NotificationSettings option
}

type Habit =
    | Binary of BinaryHabit
    | Quantifiable of QuantifiableHabit
