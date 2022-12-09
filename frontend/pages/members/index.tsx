import Head from 'next/head'
import Image from 'next/image'
import styles from '../../styles/Home.module.css'
import Navbar from '../../components/Navbar'
import { Router, useRouter } from 'next/router'

export default function MemberHome() {
  const router = useRouter();
  return (
    <>
    <div className={styles.container}>
      

      <main className={styles.main}>
      <h1 className={styles.title}>Membership</h1>

      
        <div className={styles.grid}>
          <a className={styles.card} onClick={() => router.push('/members/membership-card')}>
            <h2>Membership Card &rarr;</h2>
            <p>View membership card.</p>
          </a>

          <a className={styles.card} onClick={() => router.push('/members/upcoming-events')}>
            <h2>Upcoming Events &rarr;</h2>
            <p>View your upcoming events.</p>
          </a>

          <a className={styles.card} onClick={() => router.push('/members/previous-events')}>
            <h2>Previous Events &rarr;</h2>
            <p>View your upcoming events.</p>
          </a>

          <a className={styles.card}>
            <h2>Progress &rarr;</h2>
            <p>View previous race times.</p>
          </a>

          <a className={styles.card}>
            <h2>Subscription &rarr;</h2>
            <p>Manage your subscription.</p>
          </a>

        </div>
      </main>
    </div>
    </>
  )
}
