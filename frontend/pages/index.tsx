import styles from '../styles/Home.module.css';
import { Router, useRouter } from 'next/router';
import { Children, Component, ReactNode } from 'react';
import "react-responsive-carousel/lib/styles/carousel.min.css";
// import { Carousel } from 'react-responsive-carousel';
import { withStyles } from '@material-ui/core/styles';
import Carousel from 'react-multi-carousel';

import Image from '../components/image';

export default function Home() {
  const router = useRouter();
  
  return (
    <>
    <div className={styles.container}>
      <main className={styles.main}>
        <h1 className={styles.title}>
          Welcome to <p className='text-primary'>Pedal Power Association</p>
        </h1>

        <h1 className={styles.description}>
          Your partners in recreational cycling, development through cycling, safe cycling and advocacy.
        </h1>
      </main>
    </div>
    </>
  )
}

// export default class Index extends Component <any, any> {
//   render(): ReactNode {
//     const images = [
//       "/public/cycle1.jpg",
//       "/public/cycle2.jpg",
//     ];
//     const responsive = {
//       desktop: {
//         breakpoint: { max: 3000, min: 1024 },
//         items: 1,
//       },
//       tablet: {
//         breakpoint: { max: 1024, min: 464 },
//         items: 1,
//       },
//       mobile: {
//         breakpoint: { max: 464, min: 0 },
//         items: 1,
//       },
//     };
//     return (
//       <div className="Index">
//         <Carousel
//           responsive={responsive}
//           ssr
//           showDots={true}
//           slidesToSlide={1}
//           containerClass="container-with-dots"
//           itemClass="image-item"
//           deviceType={''}
//           centerMode={true}
//         >
//           {images.map((image) => {
//             return <Image src={image} alt={image}/>;
//           })}
//         </Carousel>
//       </div>
//     );
//   }
// }
