import Head from 'next/head'
import Image from 'next/image'
import styles from '../../styles/Home.module.css'
import Navbar from '../../components/Navbar'
import { Router, useRouter } from 'next/router'

export default function EventHome() {
  const router = useRouter();
  return (
    <>
    <div className={styles.container}>
      

      <main className={styles.main}>
        <h1 className={styles.title}>Events</h1>

        <div className={styles.grid}>
          <a className={styles.card} onClick={() => router.push('/members/membership-card')}>
            <h2>View Events &rarr;</h2>
            <p>View all events.</p>
          </a>

          <a className={styles.card} onClick={() => router.push('/members/upcoming-events')}>
            <h2>Create Event &rarr;</h2>
            <p>Create new event.</p>
          </a>

          <a className={styles.card} onClick={() => router.push('/members/previous-events')}>
            <h2>End Registration &rarr;</h2>
            <p>End event registration.</p>
          </a>

          <a className={styles.card}>
            <h2>End Event &rarr;</h2>
            <p>Finalise a race.</p>
          </a>

        </div>

      </main>
    </div>
    </>
  )
}
