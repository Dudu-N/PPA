import { SubstitutionType } from "typescript"

export enum EventFormat{
    FunRide,
    MountainBikeRide,
    SocialRide,
    PpaLeague
}

export enum UserRole{
    Admin = 0, Member = 1,Particapant = 2
}

export enum MemberType{
    Elites,
    SubVeterans,
    Veterans,
    Masters,
    JuniorScholars,
    SeniorScholars,
    Ladies
}

export interface EventDto{
    code : string,
    name: string,
    date: string,
    startVenue: string,
    routeDescription: string,
    distance: string,
    winningTime: string,
    adjustedWinningTime: string,
    eventFormat : EventFormat
}

export interface RegisterDto{
    username: string,
    password: string,
    firstName: string,
    lastName: string,
    identityNumber: string,
    age: number,
    email: string,
    chipNumber: string,
    userRole: UserRole
}

export interface RaceEntryDto{
    membershipId: string,
    eventId: string
}


export interface LoginDto{
    username : string,
    password : string
}

export interface EmergencyContact{
    name: string,
    contactNumber: string
}

export interface Member{
    memberid: string,
    userid: string,
    username: string,
    firstName: string,
    lastName: string,
    identityNumber: string,
    contactNumber: string,
    email: string,
    chipNumber: string,
    averageRaceTime: number,
    numberOfRaces: number,
    subscriptionType: string,
    emergencyContact: EmergencyContact
}

export interface Event{
    eventId: string,
    code: string,
    name: string,
    date: string,
    startVenue: string,
    routeDespription: string,
    distance: string,
    winningTime: number,
    adjustedWinningTime: number,
    format: EventFormat
}