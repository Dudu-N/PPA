import Head from 'next/head'
import Image from 'next/image'
import styles from '../../styles/Home.module.css'
import Navbar from '../../components/Navbar'
import { Router, useRouter } from 'next/router'
import { ApiClientService } from '../../service/ApiClientService'
import CenterBox from '../../components/CenterBox'
import { Member, Event as EventModel, EventFormat } from '../../models'
import { useEffect, useState } from 'react'

const defaultEvent : EventModel = {
    eventId: '', 
    code : '', 
    date: '', 
    distance: '', 
    format: EventFormat.FunRide, 
    name: '', 
    routeDespription: '', 
    startVenue: '', 
    winningTime: 0, 
    adjustedWinningTime: 0
};

export default function UpcomingEvent() {
    const apiClient = new ApiClientService();
    const router = useRouter();
    const [eventModels, setEventModels] = useState<EventModel[]>([defaultEvent]);
    useEffect(() => {
        async function getUpcomingEvents(memberId:string) {
            await apiClient.getUpcomingEvents(memberId).then(async (res)=>{
                // @ts-ignore
                setEventModels(await res.json());
                console.log("initializing", res);
                
            })
        }
        getUpcomingEvents("63938e485b1a7fee62e23133");
    },[])
    
    return (
        <>
        <div className={styles.container}>
        

        <main className={styles.main}>
            <h1 className={styles.title}>My upcoming events</h1>
            { eventModels ?
                eventModels.map((e, index) => {
                    return <div className={styles.card} key={index}>
                            
                            <h2>Event Name: {e?.name}</h2>
                            <h3>Code: {e?.code}</h3>
                            <h3>Date: {e?.date}</h3>
                            <h3>Distance: {e?.distance}</h3>
                            <h3>Route Description: {e?.routeDespription}</h3>
                            <h3>Start Venue: {e?.startVenue}</h3>
                            <h3>Race Format: {e?.format}</h3>
                
                        </div>
                    
                }) : <h3>No events found</h3>
            } 
        </main>

        </div>
        </>
  )
}
