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