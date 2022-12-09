import { LoginDto, RegisterDto, Member } from "../models/";

export class ApiClientService {

    BASE_URL = 'http://ppa-system.somee.com';
    constructor() {
        
    }

    async login(userDetails: LoginDto){
        const url = `${this.BASE_URL}/account/login`;
        const request =  {
            method: 'POST',
            body: JSON.stringify(userDetails)
        }
        console.log(request);
        
        return await fetch(url,request);
    }

    async signup(userDetails: RegisterDto){ //still working on it
        const url = `${this.BASE_URL}/signup`;
        const request =  {
            method: 'POST',
            body: JSON.stringify(userDetails)
        }
        return await fetch(url,request);
    }

    async getEvents(){
        return await fetch(`${this.BASE_URL}/`) 
    }

    async getMember(username : string) {
        const url = `${this.BASE_URL}/MemberAdmin/get-member?username=${username}`;
        const request = {
            method: 'GET'
        }
        return await fetch(url,request);
    }

    async getUpcomingEvents(memberId : string){
        const url = `${this.BASE_URL}/MemberAdmin/get-upcoming-events?memberId=${memberId}`;
        const request = {
            method: 'GET'
        }
        return await fetch(url,request);
    }

    async getPreviousEvents(memberId : string){
        const url = `${this.BASE_URL}/MemberAdmin/get-previous-events?memberId=${memberId}`;
        const request = {
            method: 'GET'
        }
        return await fetch(url,request);
    }


}