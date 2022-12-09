import '../styles/globals.css'
import '../node_modules/bootstrap/dist/css//bootstrap.css'
import type { AppProps } from 'next/app'
import Image from 'next/image'
import styles from '../styles/Home.module.css'
import Navbar from '../components/Navbar'

export default function App({ Component, pageProps }: AppProps) {
  return <>
  <header>
        <title>PPA System</title>
        <meta name="description" content="Pedal Power Associations" />
        <link rel="icon" href="/2027076.ico" />
      </header>
    <Navbar/>
    <Component {...pageProps} />
    {/* <footer className={styles.footer}>
          <a
            href="https://vercel.com?utm_source=create-next-app&utm_medium=default-template&utm_campaign=create-next-app"
            target="_blank"
            rel="noopener noreferrer"
          >
            Powered by{' '}
            <span className={styles.logo}>
              <Image src="/cycle1.jpg" alt="PPA Logo" width={72} height={16} />
            </span>
          </a>
        </footer> */}
        </>
}
