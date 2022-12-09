import Head from 'next/head'
import Image from 'next/image'
import styles from '../../styles/Home.module.css'
import Navbar from '../../components/Navbar'
import { Router, useRouter } from 'next/router'
import { ApiClientService } from '../../service/ApiClientService'
import CenterBox from '../../components/CenterBox'
import { Member } from '../../models'
import { useEffect, useState } from 'react'

const defaultMember : Member = { 
    memberid: '',
    userid: '',
    username: '',
    firstName: '',
    lastName: '',
    identityNumber: '',
    contactNumber: '',
    email: '',
    chipNumber: '',
    averageRaceTime: 0,
    numberOfRaces: 0,
    subscriptionType: '',
    emergencyContact : {name : '', contactNumber : ''}
};

export default function MembershipCard() {
    const apiClient = new ApiClientService();
    const router = useRouter();
    const [membershipDetails, seTmembershipDetails] = useState(defaultMember);
    useEffect(() => {
        async function getMember(username:string) {
            await apiClient.getMember(username).then(async (res)=>{
                // @ts-ignore
                seTmembershipDetails(await res.json());
                console.log("initializing", res);
                
            })
        }
        getMember("Heidi_Gutkowski@yahoo.com");
    },[])
    
    return (
        <>
        <div className={styles.container}>
        

        <main className={styles.main}>
            
            <a className={styles.card}>
                <h1 className={styles.title}>Membership Card</h1>
                
                <h2>First Name: {membershipDetails.firstName}</h2>
                <h2>Last Name: {membershipDetails.lastName}</h2>
                <h2>Id Number: {membershipDetails.identityNumber}</h2>
                <h2>Subscription Type: {"Individual Subscription"}</h2>
                <h2>Chip Number: {membershipDetails.chipNumber}</h2>
                
            </a>
        </main>

        </div>
        </>
  )
}
