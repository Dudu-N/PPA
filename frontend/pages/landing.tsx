import styles from '../styles/Home.module.css'
import { Router, useRouter } from 'next/router'

export default function Home() {
  const router = useRouter();
  return (
    <>
    <div className={styles.container}>
      <main className={styles.main}>

      <div className={styles.grid}>
        <a className={styles.card} onClick={()=> router.push('/members')}>
                <h2>Members &rarr;</h2>
                <p>View and manage your membership</p>
            </a>

          <a className={styles.card} onClick={()=> router.push('/events')}>
            <h2>Events &rarr;</h2>
            <p>Event administration</p>
          </a>

        </div>
      </main>
    </div>
    </>
  )
}
